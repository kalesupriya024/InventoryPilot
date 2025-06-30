using FluentValidation;
using InventoryPilot.API.Validators;
using InventoryPilot.Application.DTOs;
using InventoryPilot.Application.Interfaces;
using InventoryPilot.Application.Mapping;
using InventoryPilot.Application.Services;
using InventoryPilot.Domain.Interfaces;
using InventoryPilot.Infrastructure.Data;
using InventoryPilot.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using Asp.Versioning;


var builder = WebApplication.CreateBuilder(args);

// 1. Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Repositories & Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServicecs, ProductService>();

// 3. Register FluentValidation manually (no deprecated extensions)
builder.Services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();

// 4. Register AutoMapper with your custom MappingProfile
builder.Services.AddAutoMapper(typeof(MappingProfile));


// 5. API Versioning
builder.Services
    .AddApiVersioning(options =>
    {
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

// 6. Controllers with JSON Patch + XML Support
builder.Services.AddControllers()
    .AddXmlSerializerFormatters()
    .AddNewtonsoftJson(); // Required for PATCH (JsonPatchDocument)
// 6. Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// 7. Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InventoryPilot API",
        Version = "v1"
    });


  });

var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
