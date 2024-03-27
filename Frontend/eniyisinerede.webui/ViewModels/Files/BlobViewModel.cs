namespace eniyisinerede.webui.ViewModels.Files;

public class BlobViewModel
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? ContentType { get; set; }
    public Stream? Content { get; set; }
}
