namespace Product.API.Repositories;

public interface IProductRepository
{
    Task<List<Product.API.Entities.Product>> GetAllAsync();
    Task<Product.API.Entities.Product> GetByIdAsync(Guid id);
    Task<Product.API.Entities.Product> CreateAsync(Product.API.Entities.Product product);
    Task<Product.API.Entities.Product> UpdateAsync(Product.API.Entities.Product product);
    Task DeleteAsync(Guid id);
}
