using AutoMapper;
using InventoryPilot.Application.DTOs;
using InventoryPilot.Domain.Entities;

namespace InventoryPilot.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
