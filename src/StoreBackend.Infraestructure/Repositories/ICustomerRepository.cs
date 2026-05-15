using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infraestructure.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid customerId);
    Task<Customer> AddAsync(Customer customer);
    Task DeleteAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
}