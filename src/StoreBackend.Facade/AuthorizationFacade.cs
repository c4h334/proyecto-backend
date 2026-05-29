using StoreBackend.Dto;

namespace StoreBackend.Facade
{
    public class AuthorizationFacade : IAuthorizationFacade
    {
        public Task<AuthorizationResponseDto> AuthorizeAsync(
            AuthorizationRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}