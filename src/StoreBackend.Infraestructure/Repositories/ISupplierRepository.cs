using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infraestructure.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(Guid supplierId);
    Task<Supplier> AddAsync(Supplier supplier);
    Task DeleteAsync(Supplier supplier);
    Task<Supplier> UpdateAsync(Supplier supplier); // NUEVO
}