using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; private set; }

        [Required]
        public Guid SupplierResourceId { get; set; }

        [Required]
        [Column("CompanyName")]
        [StringLength(150)]
        public string? CompanyName { get; set; }

        [Required]
        [Column("LegalId")]
        [StringLength(20)]
        public string? LegalId { get; set; }

        [StringLength(255)]
        public string? Location { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(500)]
        public string? ProductList { get; set; }
    }
}