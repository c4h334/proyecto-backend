using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests;

public class CreateSupplierRequestModel
{
    [Required]
    [MaxLength(150)]
    public string? CompanyName { get; set; }

    [Required]
    [MaxLength(20)]
    public string? LegalId { get; set; }

    [MaxLength(255)]
    public string? Location { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }

    [MaxLength(500)]
    public string? ProductList { get; set; }
}