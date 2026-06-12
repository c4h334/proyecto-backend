namespace StoreBackend.Api.Models.Responses;

public class AuthorizationResponse
{
    public required string BearerToken { get; set; }
    public DateTime ExpiresIn { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Username { get; set; }
}