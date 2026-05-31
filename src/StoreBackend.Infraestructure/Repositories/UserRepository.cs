using Microsoft.EntityFrameworkCore;
using StoreBackend.Domain.Entities;
using StoreBackend.Infrastructure;

namespace StoreBackend.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            
            await _context.SaveChangesAsync(); 
            
            return user;
        }

        public async Task<bool> HasUserByUsernameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> HasUserByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
        
        public Task<User?> GetByUsername(string username)
        {
            return _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}