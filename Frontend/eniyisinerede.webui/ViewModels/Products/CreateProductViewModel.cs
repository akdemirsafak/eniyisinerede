using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Products;

public class CreateProductViewModel
{
    [Required, Length(1, 32)]
    [Display(Name = "Ürün adı")]
    public string Name { get; set; }
    [Display(Name = "Açıklama")]
    public string? Description { get; set; }
    [Required]
    [Range(1, 10000)]
    [Display(Name = "Fiyat")]
    public decimal Price { get; set; }
    [Display(Name = "Görsel")]
    public IFormFile Picture { get; set; }
}