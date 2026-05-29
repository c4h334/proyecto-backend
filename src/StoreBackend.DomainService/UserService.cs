using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Infraestructure.Repositories;

namespace StoreBackend.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateAsync(CreateUserDto user)
        {
            if (await _userRepository.HasUserByUsernameAsync(user.Username))
                throw new Exceptions.BadRequestResponseException("El nombre de usuario ya está en uso");

            if (await _userRepository.HasUserByEmailAsync(user.Email))
                throw new Exceptions.BadRequestResponseException("El correo electrónico ya está en uso");

            var entity = new User
            {
                UserResourceId = Guid.NewGuid(),
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
            };

            return await _userRepository.CreateAsync(entity);
        }
        public async Task<User?> GetByUserAndPassword(
    AuthorizationRequestDto requestDto)
        {
            var user =
                await _userRepository
                    .GetByUsername(requestDto.Username);

            if (user == null)
            {
                return null;
            }

            var validPassword =
                BCrypt.Net.BCrypt.Verify(
                    requestDto.Password,
                    user.PasswordHash);

            return validPassword
                ? user
                : null;
        }
    }
}