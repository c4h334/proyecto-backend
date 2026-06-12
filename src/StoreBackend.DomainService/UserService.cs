using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Infraestructure.Repositories;

namespace StoreBackend.DomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
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
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
                UserRoles = new List<UserRole>()
            };

            var customerRole = await _roleRepository.GetByNameAsync(RoleNames.Customer);
            
            if (customerRole != null)
            {
                entity.UserRoles.Add(new UserRole 
                { 
                    User = entity,
                    Role = customerRole 
                });
            }

            return await _userRepository.CreateAsync(entity);
        }

        public async Task<User?> GetByUserAndPassword(AuthorizationRequestDto requestDto)
        {
            var user = await _userRepository.GetByUsername(requestDto.Username);

            if (user == null)
            {
                return null;
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(requestDto.Password, user.PasswordHash);

            return validPassword ? user : null;
        }

        public Task<List<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task<User> UpdateAsync(Guid resourceId, UpdateUserDto userDto)
        {
            var user = await _userRepository.GetByResourceIdAsync(resourceId);
            if (user == null)
                throw new Exceptions.ResourceNotFoundException("Usuario no encontrado");

            // Validar si el nuevo username ya existe en otro usuario
            if (user.Username != userDto.Username && await _userRepository.HasUserByUsernameAsync(userDto.Username))
                throw new Exceptions.BadRequestResponseException("El nombre de usuario ya está en uso");

            // Validar si el nuevo correo ya existe en otro usuario
            if (user.Email != userDto.Email && await _userRepository.HasUserByEmailAsync(userDto.Email))
                throw new Exceptions.BadRequestResponseException("El correo electrónico ya está en uso");

            user.Name = userDto.Name;
            user.Username = userDto.Username;
            user.Email = userDto.Email;

            if (!string.IsNullOrEmpty(userDto.Password))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            }

            // Actualizar roles
            user.ClearRoles();
            foreach (var roleName in userDto.Roles)
            {
                var role = await _roleRepository.GetByNameAsync(roleName);
                if (role != null)
                {
                    user.UserRoles.Add(new UserRole
                    {
                        User = user,
                        Role = role
                    });
                }
            }

            return user;
        }

        public async Task DeleteAsync(Guid resourceId)
        {
            var user = await _userRepository.GetByResourceIdAsync(resourceId);
            if (user == null)
                throw new Exceptions.ResourceNotFoundException("Usuario no encontrado");

            await _userRepository.DeleteAsync(user);
        }
    }
}