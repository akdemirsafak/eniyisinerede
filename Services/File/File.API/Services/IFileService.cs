using File.API.Models;
using SharedLibrary.Dtos;

namespace File.API.Services;

public interface IFileService
{
    Task<ApiResponse<BlobResponseDto>> UploadAsync(IFormFile blob, string containerName);
    Task<ApiResponse<BlobDto>> DownloadAsync(string fileName, string containerName);
    Task<ApiResponse<BlobResponseDto>> DeleteAsync(string fileName, string containerName);
}
