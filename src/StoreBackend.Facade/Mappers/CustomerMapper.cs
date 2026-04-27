using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers;

public class CustomerMapper
{
    public static List<CustomerDto> ToDto(List<Customer> customers)
    {
        return customers.Select(c => ToDto(c)).ToList();
    }

    public static CustomerDto ToDto(Customer customer)
    {
        return new CustomerDto
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
