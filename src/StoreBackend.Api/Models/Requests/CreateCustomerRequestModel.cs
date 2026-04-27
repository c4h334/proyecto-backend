using System;
using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests;

public class CreateCustomerRequestModel
{
    [Required]
    [MaxLength(150)]
    public string? FullName { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Identification { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(255)]
    public string? HomeAddress { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

}
