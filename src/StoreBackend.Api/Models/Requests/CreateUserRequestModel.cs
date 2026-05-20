using System.ComponentModel.DataAnnotations;

namespace StoreBackend.Api.Models.Requests
{
    public class CreateUserRequestModel
    {
        [Required][MaxLength(50)]
        public required string Name { get; set; }

        [Required][MaxLength(50)]
        public required string Username { get; set; }

        [Required][MaxLength(100)]
        public required string Email { get; set; }

        [Required][MaxLength(255)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
            ErrorMessage = "la contraseña debe tener al menos 8 caracteres, incluyendo mayúsculas, minúsculas, números y caracteres especiales.")]
        public required string Password { get; set; }
    }
}