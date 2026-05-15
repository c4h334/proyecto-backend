using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface ISupplierFacade
{
    Task<SupplierDto> AddAsync(SupplierDto supplier);
    Task DeleteAsync(Guid supplierId);
    Task<List<SupplierDto>> GetAllAsync();
    Task<SupplierDto> GetByIdAsync(Guid supplierId);
    Task<SupplierDto> UpdateAsync(SupplierDto supplier); // NUEVO
}