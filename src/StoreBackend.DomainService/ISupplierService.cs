using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface ISupplierService
{
    Task<List<Supplier>> GetAllAsync();
    Task<Supplier?> GetByIdAsync(Guid supplierId);
    Task<Supplier> AddAsync(SupplierDto supplier);
    Task DeleteAsync(Guid supplierId);
    Task<Supplier> UpdateAsync(Guid supplierId, SupplierDto supplier); // NUEVO
}