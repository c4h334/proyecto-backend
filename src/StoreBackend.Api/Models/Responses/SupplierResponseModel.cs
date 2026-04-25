using System;

namespace StoreBackend.Api.Models.Responses;

public class SupplierResponseModel
{
    public Guid SupplierResourceId { get; set; }
    public string? CompanyName { get; set; }
    public string? LegalId { get; set; }
    public string? Location { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ProductList { get; set; }
}