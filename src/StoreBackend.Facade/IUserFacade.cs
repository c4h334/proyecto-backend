using StoreBackend.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreBackend.Facade
{
    public interface IUserFacade
    {
        Task<UserDto> CreateAsync(CreateUserDto user);

        Task<UserDto> CreateAdminAsync(CreateUserDto user);

        Task<List<UserDto>> GetAllAsync();

        Task<UserDto> UpdateAsync(Guid resourceId, UpdateUserDto userDto);

        Task DeleteAsync(Guid resourceId);
    }
}