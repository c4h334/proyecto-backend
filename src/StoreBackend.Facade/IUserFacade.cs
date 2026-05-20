using StoreBackend.Dto;

namespace StoreBackend.Facade
{
    public interface IUserFacade
    {
        Task<UserDto> CreateAsync(CreateUserDto user);
    }
}