using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infraestructure.Repositories;


namespace StoreBackend.DomainService;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<List<Customer>> GetAllAsync()
    {
        return _customerRepository.GetAllAsync();
    }

    public Task<Customer?> GetByIdAsync(Guid customerId)
    {
        return _customerRepository.GetByIdAsync(customerId);
    }

    public Task<Customer> AddAsync(CustomerDto customer)
    {
        var customerEntity = new Customer
        {
            CustomerResourceId = customer.CustomerResourceId,
            FullName = customer.FullName,
            Identification = customer.Identification,
            Phone = customer.Phone,
            HomeAddress = customer.HomeAddress,
            Email = customer.Email
        };
        return _customerRepository.AddAsync(customerEntity);
    }

    public async Task DeleteAsync(Guid customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null) throw new ResourceNotFoundException();
        await _customerRepository.DeleteAsync(customer);
    }
}
