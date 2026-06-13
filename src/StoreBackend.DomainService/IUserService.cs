using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBackend.DomainService
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto user);

        Task<User?> GetByUserAndPassword(
            AuthorizationRequestDto requestDto);

        Task<User> CreateAdminAsync(CreateUserDto user);

        Task<List<User>> GetAllAsync();

        Task<User> UpdateAsync(Guid resourceId, UpdateUserDto userDto);

        Task DeleteAsync(Guid resourceId);
    }
}