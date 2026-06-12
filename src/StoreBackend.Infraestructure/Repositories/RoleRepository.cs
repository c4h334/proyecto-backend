using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;
using StoreBackend.Infrastructure; // Asegúrate de que el namespace de tu AppDbContext esté aquí

namespace StoreBackend.Infraestructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}