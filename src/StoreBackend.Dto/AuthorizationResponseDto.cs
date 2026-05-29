public class AuthorizationResponseDto
{
    public required string BearerToken { get; set; }
    public DateTime ExpiresIn { get; set; }
}