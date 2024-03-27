using File.API.Models;
using SharedLibrary.Dtos;

namespace File.API.Services;

public class FileService(IAzureBlobStorageService _azureBlobStorageService) : IFileService
{
    public async Task<ApiResponse<BlobResponseDto>> DeleteAsync(string fileName, string containerName)
    {
        var response = await _azureBlobStorageService.DeleteAsync(fileName, containerName);
        return ApiResponse<BlobResponseDto>.Success(response);
    }

    public async Task<ApiResponse<BlobDto>> DownloadAsync(string fileName, string containerName)
    {
        var response = await _azureBlobStorageService.DownloadAsync(fileName, containerName);
        if (response == null)
            return ApiResponse<BlobDto>.Fail("File not found", 404);
        return ApiResponse<BlobDto>.Success(response);
    }

    public async Task<ApiResponse<BlobResponseDto>> UploadAsync(IFormFile blob, string containerName)
    {
        var response = await _azureBlobStorageService.UploadAsync(blob, containerName);
        return ApiResponse<BlobResponseDto>.Success(response);
    }
}
