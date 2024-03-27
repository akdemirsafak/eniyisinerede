using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Files;
using SharedLibrary.Dtos;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eniyisinerede.webui.Services;

public class ImageService : IImageService
{

    private readonly HttpClient _httpClient;

    public ImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);

        var multipartContent = new MultipartFormDataContent();
        var fileBytes = ms.ToArray();
        var imageContent = new ByteArrayContent(fileBytes);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
        multipartContent.Add(imageContent, "image", file.FileName);



        var requestResponse= await _httpClient.PostAsync("image",multipartContent);

        if (!requestResponse.IsSuccessStatusCode)
            throw new HttpRequestException("Bad request error");

        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<BlobResponseViewModel>>();
        if (responseContent?.Data?.Blob?.Url == null)
            throw new NullReferenceException("Response content is null or has null properties");

        return responseContent.Data.Blob.Url;
    }

    public async Task<BlobResponseViewModel> DeleteAsync(string fileName)
    {
        var requestResponse = await _httpClient.DeleteAsync($"image/{fileName}");
        if (!requestResponse.IsSuccessStatusCode)
            throw new HttpRequestException("Bad request error");
        var responseContent = await requestResponse.Content.ReadFromJsonAsync<ApiResponse<BlobResponseViewModel>>();

        if (responseContent?.Data is null)
            throw new NullReferenceException("Response content is null or has null properties");
        
        return responseContent.Data;

    }

    public Task<ApiResponse<BlobViewModel>> DownloadAsync(string fileName)
    {
        throw new NotImplementedException();
    }
}
