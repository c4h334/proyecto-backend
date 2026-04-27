using System;
using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;


namespace StoreBackend.Facade;

public class CustomerFacade : ICustomerFacade
{
    private readonly ICustomerService customerService;
    private readonly AppDbContext context;

    public CustomerFacade(ICustomerService customerService, AppDbContext context)
    {
        this.customerService = customerService;
        this.context = context;
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var entities = await customerService.GetAllAsync();
        return CustomerMapper.ToDto(entities);
    }

    public async Task<CustomerDto> GetByIdAsync(Guid customerId)
    {
        var entity = await customerService.GetByIdAsync(customerId);
        if (entity == null) throw new ResourceNotFoundException();
        return CustomerMapper.ToDto(entity);
    }

    public async Task<CustomerDto> AddAsync(CustomerDto customer)
    {
        var entity = await customerService.AddAsync(customer);
        await context.SaveChangesAsync();
        return CustomerMapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid customerId)
    {
        await customerService.DeleteAsync(customerId);
        await context.SaveChangesAsync();
    }
}
