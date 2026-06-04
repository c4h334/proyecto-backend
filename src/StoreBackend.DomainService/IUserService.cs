using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto user);

        Task<User?> GetByUserAndPassword(
            AuthorizationRequestDto requestDto);

            Task<User> CreateAdminAsync(CreateUserDto user);
    }
}