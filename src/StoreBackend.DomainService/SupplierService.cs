using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infraestructure.Repositories;

namespace StoreBackend.DomainService;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public Task<List<Supplier>> GetAllAsync()
    {
        return _supplierRepository.GetAllAsync();
    }

    public Task<Supplier?> GetByIdAsync(Guid supplierId)
    {
        return _supplierRepository.GetByIdAsync(supplierId);
    }

    public Task<Supplier> AddAsync(SupplierDto supplier)
    {
        var entity = new Supplier
        {
            SupplierResourceId = supplier.SupplierResourceId,
            CompanyName = supplier.CompanyName,
            LegalId = supplier.LegalId,
            Location = supplier.Location,
            Phone = supplier.Phone,
            Email = supplier.Email,
            ProductList = supplier.ProductList
        };
        return _supplierRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid supplierId)
    {
        var supplier = await _supplierRepository.GetByIdAsync(supplierId);
        if (supplier == null) throw new ResourceNotFoundException();
        await _supplierRepository.DeleteAsync(supplier);
    }

    public async Task<Supplier> UpdateAsync(Guid supplierId, SupplierDto supplierDto)
    {
        var supplier = await _supplierRepository.GetByIdAsync(supplierId);
        if (supplier == null) throw new ResourceNotFoundException();
        
        supplier.CompanyName = supplierDto.CompanyName;
        supplier.LegalId = supplierDto.LegalId;
        supplier.Location = supplierDto.Location;
        supplier.Phone = supplierDto.Phone;
        supplier.Email = supplierDto.Email;
        supplier.ProductList = supplierDto.ProductList;

        return await _supplierRepository.UpdateAsync(supplier);
    }
}