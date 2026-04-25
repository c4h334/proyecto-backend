using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers;

public class SupplierMapper
{
    public static List<SupplierDto> ToDto(List<Supplier> suppliers)
    {
        return suppliers.Select(s => ToDto(s)).ToList();
    }

    public static SupplierDto ToDto(Supplier supplier)
    {
        return new SupplierDto
        {
            SupplierResourceId = supplier.SupplierResourceId,
            CompanyName = supplier.CompanyName,
            LegalId = supplier.LegalId,
            Location = supplier.Location,
            Phone = supplier.Phone,
            Email = supplier.Email,
            ProductList = supplier.ProductList
        };
    }
}