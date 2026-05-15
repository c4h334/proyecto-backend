using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface ICustomerFacade
{
    Task<CustomerDto> AddAsync(CustomerDto customer);
    Task DeleteAsync(Guid customerId);
    Task<List<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(Guid customerId);
    Task<CustomerDto> UpdateAsync(CustomerDto customer);
}