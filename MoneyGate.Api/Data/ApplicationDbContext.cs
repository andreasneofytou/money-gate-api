using Microsoft.EntityFrameworkCore;
using MoneyGate.Api.Data.Entities;
using MoneyGate.Api.Products.Entities;

namespace MoneyGate.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}