﻿using System.ComponentModel.DataAnnotations;

namespace eniyisinerede.webui.ViewModels.Countries;

public class CountryViewModel
{
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
