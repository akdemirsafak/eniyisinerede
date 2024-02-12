using Microsoft.EntityFrameworkCore;
using Product.API.DbContexts;
namespace Product.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApiDbContext _dbContext;

    public ProductRepository(ApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Entities.Product> CreateAsync(Entities.Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product=await _dbContext.Products.FindAsync(id);
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<List<Entities.Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Entities.Product> GetByIdAsync(Guid id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<Entities.Product> UpdateAsync(Entities.Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}
