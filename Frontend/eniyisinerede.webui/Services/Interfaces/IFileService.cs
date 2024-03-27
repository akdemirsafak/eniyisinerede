using eniyisinerede.webui.ViewModels.Files;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file, string containerName);
    Task<BlobResponseViewModel> DeleteAsync(string fileName);
    Task<ApiResponse<BlobViewModel>> DownloadAsync(string fileName);
}
