using Microsoft.AspNetCore.Mvc;
using MoneyGate.Api.Products.Entities;
using MoneyGate.Api.Products.Models;

namespace MoneyGate.Api.Products;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(ProductsService productsService) : Controller()
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var products = await productsService.GetProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id)
    {
        var product = await productsService.GetProductAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] ProductModel model)
    {
        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            Quantity = model.Quantity
        };

        await productsService.AddProductAsync(product, saveChanges: true);

        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] ProductModel model)
    {
        var product = await productsService.GetProductAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.Quantity = model.Quantity;

        await productsService.UpdateProductAsync(product, saveChanges: true);

        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var product = await productsService.GetProductAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        await productsService.DeleteProductAsync(product, saveChanges: true);

        return NoContent();
    }
}