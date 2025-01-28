using System.ComponentModel.DataAnnotations;
using MoneyGate.Api.Data.Entities;

namespace MoneyGate.Api.Products.Entities;

public class Product : BaseEntity
{
    [MaxLength(250)]
    public required string Name { get; set; }

    public required decimal Price { get; set; }

    public required int Quantity { get; set; }

    [MaxLength(500)]
    public required string Description { get; set; }
}