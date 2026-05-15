using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _productRepository.GetAllAsync();
    }

    public Task<Product?> GetByIdAsync(Guid productId)
    {
        return _productRepository.GetByIdAsync(productId);
    }

    public Task<Product> AddAsync(ProductDto product)
    {
        var productEntity = new Product
        {
            ProductResourceId = product.ProductResourceId,
            Name = product.Name,
            Description = product.Description,
            Quantity = product.Quantity,
            Price = product.Price,
            Code = product.Code,
            Image = product.Image,
            Available = product.Available,
            Discount = product.Discount,
            DiscountQuantity = product.DiscountQuantity,
            Material = product.Material
        };
        return _productRepository.AddAsync(productEntity);
    }

    public async Task DeleteAsync(Guid productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null) throw new ResourceNotFoundException();
        await _productRepository.DeleteAsync(product);
    }

    public async Task<Product> UpdateAsync(Guid productId, ProductDto productDto)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product == null) throw new ResourceNotFoundException();
        product.ProductResourceId = productDto.ProductResourceId;
        product.Name = productDto.Name;
        product.Description = productDto.Description;
        product.Quantity = productDto.Quantity;
        product.Price = productDto.Price;
        product.Code = productDto.Code;
        product.Image = productDto.Image;
        product.Available = productDto.Available;
        product.Discount = productDto.Discount;
        product.DiscountQuantity = productDto.DiscountQuantity;
        product.Material = productDto.Material;
        return await _productRepository.UpdateAsync(product);
    }
}