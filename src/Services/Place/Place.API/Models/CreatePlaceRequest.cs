using System.ComponentModel.DataAnnotations;

namespace Place.API.Models;

public record CreatePlaceRequest(
    [Required,Length(1,32)] string Name,
    string? Description,
    [Required,Length(1,128)]string Address,
    string? PhotoUrl);

