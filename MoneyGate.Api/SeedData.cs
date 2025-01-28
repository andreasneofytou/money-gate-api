using MoneyGate.Api.Data;
using MoneyGate.Api.Data.Entities;
using MoneyGate.Api.Products.Entities;

namespace MoneyGate.Api;

public static class SeedData
{
    private static ApplicationDbContext dbContext;

    public static void Initialize(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>() ??
                    throw new ArgumentNullException(nameof(dbContext));

        CreateProducts();
    }

    private static void CreateProducts()
    {
        var products = dbContext.Products.ToList();
        if (products.Count == 0)
        {
            dbContext.Products.AddRange(new[]
            {
                new Product
                {
                    Name = "Product 1",
                    Description = "Description 1",
                    Price = 100,
                    Quantity = 10
                },
                new Product
                {
                    Name = "Product 2",
                    Description = "Description 2",
                    Price = 200,
                    Quantity = 20
                },
                new Product
                {
                    Name = "Product 3",
                    Description = "Description 3",
                    Price = 300,
                    Quantity = 30
                }
            });

            dbContext.SaveChanges();
        }
    }
}