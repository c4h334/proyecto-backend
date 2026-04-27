using System;
using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Exceptions;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerFacade customerFacade;

    public CustomerController(ICustomerFacade customerFacade)
    {
        this.customerFacade = customerFacade;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await customerFacade.GetAllAsync();
        var models = CustomerMapper.ToModel(customers);
        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(Guid id)
    {
        try
        {
            var customer = await customerFacade.GetByIdAsync(id);
            var model = CustomerMapper.ToModel(customer);
            return Ok(model);
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer([FromBody] CreateCustomerRequestModel customer)
    {
        var dto = CustomerMapper.ToDto(customer);
        var addedCustomer = await customerFacade.AddAsync(dto);
        var model = CustomerMapper.ToModel(addedCustomer);
        return CreatedAtAction(nameof(GetCustomer), new { id = model.CustomerResourceId }, model);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(Guid id)
    {
        try
        {
            await customerFacade.DeleteAsync(id);
            return Ok();
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
    }
}