using System;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface ICustomerFacade
{
    Task<List<CustomerDto>> GetAllAsync();
    Task<CustomerDto> GetByIdAsync(Guid customerId);
    Task<CustomerDto> AddAsync(CustomerDto customer);
    Task DeleteAsync(Guid customerId);

}
