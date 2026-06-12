using StoreBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBackend.Infraestructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<bool> HasUserByUsernameAsync(string username);

        Task<bool> HasUserByEmailAsync(string email);

        Task<User?> GetByUsername(string username);

        Task<List<User>> GetAllAsync();

        Task<User?> GetByResourceIdAsync(Guid resourceId);

        Task DeleteAsync(User user);
    }
}