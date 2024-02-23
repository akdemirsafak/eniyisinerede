namespace File.API.Models;

public class BlobResponseDto
{
    public BlobResponseDto()
    {
    }
    public BlobResponseDto(BlobDto blob)
    {
        Blob = blob;
    }
    public BlobDto Blob { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
}
