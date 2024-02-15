using eniyisinerede.webui.ViewModels.Files;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IImageService
{
    Task<string> UploadAsync(IFormFile file);
    Task<BlobResponseViewModel> DeleteAsync(string fileName);
    Task<ApiResponse<BlobViewModel>> DownloadAsync(string fileName);
}
