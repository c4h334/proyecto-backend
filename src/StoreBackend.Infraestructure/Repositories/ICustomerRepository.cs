using System;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infraestructure.Repositories;

public interface ICustomerRepository
{

    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid customerId);
    Task<Customer> AddAsync(Customer customer);
    Task DeleteAsync(Customer customer);

}
