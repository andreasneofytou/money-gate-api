using Microsoft.EntityFrameworkCore;
using MoneyGate.Api.Data;
using MoneyGate.Api.Products.Entities;

namespace MoneyGate.Api.Products;

public class ProductsService(ApplicationDbContext dbContext)
{
    private readonly DbSet<Product> products = dbContext.Products;

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await products.ToListAsync();
    }

    public async Task<Product?> GetProductAsync(Guid id)
    {
        return await products.FindAsync(id);
    }

    public async Task AddProductAsync(Product product, bool saveChanges = true)
    {
        await products.AddAsync(product);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateProductAsync(Product product, bool saveChanges = true)
    {
        products.Update(product);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteProductAsync(Product product, bool saveChanges = true)
    {
        products.Remove(product);

        if (saveChanges)
        {
            await dbContext.SaveChangesAsync();
        }
    }
}