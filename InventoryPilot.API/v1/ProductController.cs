using InventoryPilot.Application.DTOs;
using InventoryPilot.Application.Interfaces;
using InventoryPilot.Application.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPilot.API.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json", "application/xml")]
public class ProductController : ControllerBase
{
    private readonly IProductServicecs _service;

    public ProductController(IProductServicecs service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> Get(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] ProductDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        await _service.UpdateAsync(id,dto);
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<ProductDto> patchDoc)
    {
        if (patchDoc == null)
            return BadRequest();

        var product = await _service.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        patchDoc.ApplyTo(product);

        if (!TryValidateModel(product))
            return ValidationProblem(ModelState);

        await _service.UpdateAsync(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
