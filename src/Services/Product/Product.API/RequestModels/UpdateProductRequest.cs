using System.ComponentModel.DataAnnotations;

namespace Product.API.RequestModels;

public record UpdateProductRequest(
    [Required, Length(1, 32)] string Name,
    string? Description,
    decimal Price,
    string? PictureUrl);
