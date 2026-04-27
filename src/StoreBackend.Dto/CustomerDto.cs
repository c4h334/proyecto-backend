using System;

namespace StoreBackend.Dto;

public class CustomerDto
{

    public Guid CustomerResourceId { get; set; }
    public string? FullName { get; set; }
    public string? Identification { get; set; }
    public string? Phone { get; set; }
    public string? HomeAddress { get; set; }
    public string? Email { get; set; }

}
