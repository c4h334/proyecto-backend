using System;
using StoreBackend.Dto;

namespace StoreBackend.Facade;

public interface ISupplierFacade
{
    Task<List<SupplierDto>> GetAllAsync();
    Task<SupplierDto> GetByIdAsync(Guid supplierId);
    Task<SupplierDto> AddAsync(SupplierDto supplier);
    Task DeleteAsync(Guid supplierId);
}