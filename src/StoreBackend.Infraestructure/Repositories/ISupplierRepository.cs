using System;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(Guid supplierId);
    Task<Supplier> AddAsync(Supplier supplier);
    Task DeleteAsync(Supplier supplier);
}