using System;
using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;

namespace StoreBackend.Facade;

public class SupplierFacade : ISupplierFacade
{
    private readonly ISupplierService supplierService;
    private readonly AppDbContext context;

    public SupplierFacade(ISupplierService supplierService, AppDbContext context)
    {
        this.supplierService = supplierService;
        this.context = context;
    }

    public async Task<SupplierDto> AddAsync(SupplierDto supplier)
    {
        var entity = await supplierService.AddAsync(supplier);
        await context.SaveChangesAsync();
        return SupplierMapper.ToDto(entity);
    }

    public async Task DeleteAsync(Guid supplierId)
    {
        await supplierService.DeleteAsync(supplierId);
        await context.SaveChangesAsync();
    }

    public async Task<List<SupplierDto>> GetAllAsync()
    {
        var entities = await supplierService.GetAllAsync();
        return SupplierMapper.ToDto(entities);
    }

    public async Task<SupplierDto> GetByIdAsync(Guid supplierId)
    {
        var entity = await supplierService.GetByIdAsync(supplierId);
        if (entity == null) throw new ResourceNotFoundException();
        return SupplierMapper.ToDto(entity);
    }
}