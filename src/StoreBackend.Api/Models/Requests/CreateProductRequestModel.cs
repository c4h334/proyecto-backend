using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests;

public class CreateProductRequestModel
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Code { get; set; }

    [MaxLength(500)]
    public string? Image { get; set; }

    public bool Available { get; set; } = true;

    [Range(0, 100)]
    public decimal Discount { get; set; } = 0;

    [Range(0, int.MaxValue)]
    public int DiscountQuantity { get; set; } = 0;

    [MaxLength(100)]
    public string? Material { get; set; }
}