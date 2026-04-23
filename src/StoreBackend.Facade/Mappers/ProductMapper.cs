using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers;

public class ProductMapper
{
    public static List<ProductDto> ToDto(List<Product> products)
    {
        return products.Select(p => ToDto(p)).ToList();
    }

    public static ProductDto ToDto(Product product)
    {
        return new ProductDto
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

    }
}
