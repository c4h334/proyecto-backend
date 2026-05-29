using StoreBackend.Domain.Entities;

namespace StoreBackend.Infraestructure.Repositories
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllAsync();
    }
}