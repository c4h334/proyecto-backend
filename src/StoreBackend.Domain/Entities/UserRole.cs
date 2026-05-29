using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        public Guid UserRoleResourceId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;
    }
}