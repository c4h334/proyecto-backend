using System;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers;

public class ProductMapper
{
    public static ProductDto ToDto(CreateProductRequestModel model)
    {
        return new ProductDto
        {
            ProductResourceId = Guid.NewGuid(),
            Name = model.Name,
            Description = model.Description,
            Quantity = model.Quantity,
            Price = model.Price,
            Code = model.Code,
            Image = model.Image,
            Available = model.Available,
            Discount = model.Discount,
            DiscountQuantity = model.DiscountQuantity,
            Material = model.Material
        };
    }

    public static List<ProductResponseModel> ToModel(List<ProductDto> products)
    {
        return products.Select(p => ToModel(p)).ToList();
    }

    public static ProductResponseModel ToModel(ProductDto product)
    {
        return new ProductResponseModel
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