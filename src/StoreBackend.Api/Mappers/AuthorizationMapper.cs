using StoreBackend.Api.Models.Responses;
using StoreBackend.Dto;
using StoreBackend.Api.Models.Requests;

namespace StoreBackend.Api.Mappers;

public static class AuthorizationMapper
{
    public static AuthorizationRequestDto ToDto(
        AuthorizationRequestModel model)
    {
        return new AuthorizationRequestDto
        {
            Username = model.Username,
            Password = model.Password,
        };
    }

    public static AuthorizationResponse ToResponse(
        AuthorizationResponseDto dto)
    {
        return new AuthorizationResponse
        {
            BearerToken = dto.BearerToken,
            ExpiresIn = dto.ExpiresIn,
        };
    }
}