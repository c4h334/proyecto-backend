using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreBackend.Domain.Entities
{
    [Table("Product")] // Mapea a la tabla Product
    public class Product
    {
        [Key] // Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincremental (IDENTITY)
        public int ProductId { get; private set; }

        [Required] // Campo obligatorio
        public Guid ProductResourceId { get; set; }

        [Required] // Campo obligatorio
        [Column("Name")] // Mapea a la columna Name
        [StringLength(50)] // Máximo 50 caracteres
        public string? Name { get; set; }
    }
}