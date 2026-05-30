namespace StoreBackend.Dto
{
    public class AuthorizationResponseDto
    {
        public required string BearerToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}