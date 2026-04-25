using System;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers;

public class SupplierMapper
{
    public static SupplierDto ToDto(CreateSupplierRequestModel model)
    {
        return new SupplierDto
        {
            SupplierResourceId = Guid.NewGuid(),
            CompanyName = model.CompanyName,
            LegalId = model.LegalId,
            Location = model.Location,
            Phone = model.Phone,
            Email = model.Email,
            ProductList = model.ProductList
        };
    }

    public static List<SupplierResponseModel> ToModel(List<SupplierDto> suppliers)
    {
        return suppliers.Select(s => ToModel(s)).ToList();
    }

    public static SupplierResponseModel ToModel(SupplierDto supplier)
    {
        return new SupplierResponseModel
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