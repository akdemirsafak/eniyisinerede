using System.ComponentModel.DataAnnotations;

namespace Product.API.Entities;

public class Product : IAuditableEntity
{
    public Guid Id { get; set; }
    [Required,Length(1,32)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    public DateTime CreatedAt { get ; set ; }
    public string? CreatedBy { get ; set; }
    public DateTime? UpdatedAt { get ; set ; }
    public string? UpdatedBy { get ; set ; }
}
