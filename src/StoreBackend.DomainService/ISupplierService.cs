using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface ISupplierService
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(Guid supplierId);
    Task<Supplier> AddAsync(SupplierDto supplier);
    Task DeleteAsync(Guid supplierId);
}