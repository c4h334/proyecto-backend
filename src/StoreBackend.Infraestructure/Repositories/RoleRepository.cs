using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;
using StoreBackend.Infrastructure;

namespace StoreBackend.Infraestructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Role>> GetAllAsync()
        {
            return _context.Roles.ToListAsync();
        }
    }
}