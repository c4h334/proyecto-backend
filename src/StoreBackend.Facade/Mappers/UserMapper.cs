using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.Facade.Mappers
{
    public class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                UserResourceId = user.UserResourceId,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
            };
        }
    }
}