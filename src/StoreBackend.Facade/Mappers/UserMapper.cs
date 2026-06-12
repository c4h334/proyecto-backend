using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using System.Linq;

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
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }
    }
}