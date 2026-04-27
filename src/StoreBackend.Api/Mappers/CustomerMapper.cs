using System;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers;

public class CustomerMapper
{
    public static CustomerDto ToDto(CreateCustomerRequestModel model)
    {
        return new CustomerDto
        {
            CustomerResourceId = Guid.NewGuid(),
            FullName = model.FullName,
            Identification = model.Identification,
            Phone = model.Phone,
            HomeAddress = model.HomeAddress,
            Email = model.Email
        };
    }

    public static List<CustomerResponseModel> ToModel(List<CustomerDto> customers)
    {
        return customers.Select(c => ToModel(c)).ToList();
    }

    public static CustomerResponseModel ToModel(CustomerDto customer)
    {
        return new CustomerResponseModel
        {
            CustomerResourceId = customer.CustomerResourceId,
            FullName = customer.FullName,
            Identification = customer.Identification,
            Phone = customer.Phone,
            HomeAddress = customer.HomeAddress,
            Email = customer.Email
        };
    }


}
