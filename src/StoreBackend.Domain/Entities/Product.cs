using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities
{
    [Table("Products")] // Mapea a la tabla Product
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; private set; }

        [Required]
        public Guid ProductResourceId { get; set; }

        [Required]
        [Column("Name")]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string? Code { get; set; }

        [StringLength(500)]
        public string? Image { get; set; }

        [Required]
        public bool Available { get; set; } = true;

        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; } = 0;

        public int DiscountQuantity { get; set; } = 0;

        [StringLength(100)]
        public string? Material { get; set; }
    }
}