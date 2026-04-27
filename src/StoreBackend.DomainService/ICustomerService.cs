using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface ICustomerService
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid customerId);
    Task<Customer> AddAsync(CustomerDto customer);
    Task DeleteAsync(Guid customerId);

}
