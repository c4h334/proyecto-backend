using System; // Espacio de nombres base de .NET
using System.Net.Http.Headers; // (No se está usando aquí, pero está importado)
using Microsoft.EntityFrameworkCore; // Entity Framework Core
using StoreBackend.Domain.Entities; // Donde está la entidad Product

namespace StoreBackend.Infrastructure;

// Clase que representa el contexto de base de datos
public class AppDbContext : DbContext
{
    // Constructor que recibe las opciones de configuración del DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    // Representa la tabla Product en la base de datos
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
}