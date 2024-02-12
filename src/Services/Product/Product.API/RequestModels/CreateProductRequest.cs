using System.ComponentModel.DataAnnotations;

namespace Product.API.RequestModels;

public record CreateProductRequest(
    [Required, Length(1, 32)] string Name,
    string? Description,
    decimal Price,
    string? Picture);

