using File.API.Models;

namespace File.API.Services;

public interface IAzureBlobStorageService
{
    //Task<List<BlobDto>> ListAsync(string containerName);
    Task<BlobResponseDto> UploadAsync(IFormFile blob, string containerName);
    Task<BlobDto> DownloadAsync(string fileName, string containerName);

    Task<BlobResponseDto> DeleteAsync(string fileName, string containerName);
}
