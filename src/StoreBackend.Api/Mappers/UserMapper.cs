using StoreBackend.Api.Models.Requests;
using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;

namespace StoreBackend.Api.Mappers
{
    public class UserMapper
    {
        public static CreateUserDto ToDto(CreateUserRequestModel user)
        {
            return new CreateUserDto
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
            };
        }

        public static UserResponseModel ToModel(UserDto user)
        {
            return new UserResponseModel
            {
                UserResourceId = user.UserResourceId,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
            };
        }
    }
}