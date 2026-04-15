using System; // Espacio de nombres base
using StoreBackend.Domain.Entities; // Donde está la entidad Product

namespace StoreBackend.Infrastructure.Repositories;

// Interfaz que define las operaciones del repositorio de productos
public interface IProductRepository
{
    // Obtiene todos los productos de forma asíncrona
    Task<List<Product>> GetAllAsync();

    // Obtiene un producto por su identificador (Guid)
    Task<Product?> GetByIdAsync(Guid productId);

    // Agrega un nuevo producto a la base de datos
    Task<Product> AddAsync(Product product);

    // Elimina un producto existente
    Task DeleteAsync(Product product);
}