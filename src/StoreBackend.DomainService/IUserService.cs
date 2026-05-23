using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto user);
    }
}