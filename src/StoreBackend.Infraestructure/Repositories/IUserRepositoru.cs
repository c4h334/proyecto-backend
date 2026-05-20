using StoreBackend.Domain.Entities;

namespace StoreBackend.Infraestructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<bool> HasUserByUsernameAsync(string username);
        Task<bool> HasUserByEmailAsync(string email);
    }
}