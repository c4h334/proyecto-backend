using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; private set; }

        [Required]
        public Guid CustomerResourceId { get; set; }

        [Required]
        [StringLength(150)]
        public string? FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string? Identification { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(255)]
        public string? HomeAddress { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }
    }
}