using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Products;

public class UpdateProductViewModel
{
    public Guid Id { get; set; }
    [Required,Length(1,32)]
    [Display(Name = "Ürün adı")]
    public string Name { get; set; }
    [Display(Name = "Açıklama")]
    public string? Description { get; set; }
    [Required]
    [Display(Name = "Fiyat")]
    [Range(1,10000)]
    public decimal Price { get; set; }
    [Display(Name = "Resim URL")]
    public string? PictureUrl { get; set; }
}
