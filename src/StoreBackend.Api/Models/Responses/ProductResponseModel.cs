using System;

namespace StoreBackend.Api.Models.Responses;

public class ProductResponseModel
{
    public Guid ProductResourceId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string? Code { get; set; }
    public string? Image { get; set; }
    public bool Available { get; set; }
    public decimal Discount { get; set; }
    public int DiscountQuantity { get; set; }
    public string? Material { get; set; }
}
