using StoreBackend.DomainService;
using StoreBackend.Dto;
using StoreBackend.Facade.Mappers;
using StoreBackend.Infrastructure;

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
    }
}