using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBackend.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserService _userService;
        private readonly AppDbContext context;

        public UserFacade(IUserService userService, AppDbContext context)
        {
            _userService = userService;
            this.context = context;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto user)
        {
            var entity = await _userService.CreateAsync(user);
            await context.SaveChangesAsync();
            return UserMapper.ToDto(entity);
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var entities = await _userService.GetAllAsync();
            return entities.Select(UserMapper.ToDto).ToList();
        }

        public async Task<UserDto> UpdateAsync(Guid resourceId, UpdateUserDto userDto)
        {
            var entity = await _userService.UpdateAsync(resourceId, userDto);
            await context.SaveChangesAsync();
            return UserMapper.ToDto(entity);
        }

        public async Task DeleteAsync(Guid resourceId)
        {
            await _userService.DeleteAsync(resourceId);
            await context.SaveChangesAsync();
        }
    }
}