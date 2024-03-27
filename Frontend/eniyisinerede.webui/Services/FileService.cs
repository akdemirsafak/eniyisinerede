using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Files;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class FileService : IFileService
{
    private readonly HttpClient _httpClient;

    public FileService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<BlobResponseViewModel> DeleteAsync(string fileName)
    {
        //var requestResponse = await _httpClient.DeleteAsync($"files/{fileName}");
        throw new NotImplementedException();
    }

    public Task<ApiResponse<BlobViewModel>> DownloadAsync(string fileName)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadAsync(IFormFile file,string containerName)
    {
        var requestResponse= await _httpClient.PostAsJsonAsync("file",file);
        if (!requestResponse.IsSuccessStatusCode)
            return null;

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<BlobResponseViewModel>>();
        return responseContent.Data.Blob.Url;
    }

}
