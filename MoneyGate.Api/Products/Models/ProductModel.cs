using System.ComponentModel.DataAnnotations;

namespace MoneyGate.Api.Products.Models;

public class ProductModel
{
    [Required]
    [MinLength(2, ErrorMessage = "Name is too short")]
    [MaxLength(250, ErrorMessage = "Name is too long")]
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(500, ErrorMessage = "Description is too long")]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Price")]
    [Range(0, float.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Quantity")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public int Quantity { get; set; }
}