using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Auth;

public record SignUpInputModel(
    [Required]
    string Email,
    [Required]
    string Username,
    [Required]
    string Password);
