﻿using AutoMapper;
using InventoryPilot.Application.DTOs;
using InventoryPilot.Application.Interfaces;
using InventoryPilot.Domain.Entities;
using InventoryPilot.Domain.Interfaces;

namespace InventoryPilot.Application.Services;

public class ProductService : IProductServicecs
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(Guid id)
    {
        var product = await _repo.GetByIdAsync(id);
        return _mapper.Map<ProductDto?>(product);
    }

    public async Task AddAsync(ProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _repo.AddAsync(product);
    }

    public async Task UpdateAsync(Guid id, ProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        product.Id = id;
        await _repo.UpdateAsync(product);
    }

    public async Task DeleteAsync(Guid id) =>
        await _repo.DeleteAsync(id);
}