using System;
using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;

namespace StoreBackend.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;

    public SupplierRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers.ToListAsync();
    }

    public async Task<Supplier?> GetByIdAsync(Guid supplierId)
    {
        return await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierResourceId == supplierId);
    }

    public async Task<Supplier> AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        return supplier;
    }

    public async Task DeleteAsync(Supplier supplier)
    {
        _context.Suppliers.Remove(supplier);
    }
}