using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using File.API.Models;

namespace File.API.Services;

public class AzureBlobStorageService(BlobServiceClient _blobServiceClient) : IAzureBlobStorageService
{
    public async Task<BlobResponseDto> DeleteAsync(string fileName, string containerName)
    {
        var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = blobContainerClient.GetBlobClient(fileName);
        await blobClient.DeleteIfExistsAsync();
        return new BlobResponseDto
        {
            IsSuccess = true,
            Message = $"{fileName} deleted successfully"
        };
    }

    public async Task<BlobDto> DownloadAsync(string fileName, string containerName)
    {
        BlobContainerClient blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var file = blobContainerClient.GetBlobClient(fileName);
        if (await file.ExistsAsync())
        {
            BlobDownloadInfo downloadInfo = await file.DownloadAsync();
            return new BlobDto()
            {
                Url = file.Uri.AbsoluteUri,
                ContentType = downloadInfo.ContentType,
                Name = file.Name,
                Content = downloadInfo.Content
            };
        }
        return null;
    }

    //public async Task<List<BlobDto>> ListAsync(string containerName)
    //{
    //    List<BlobDto> files= new();
    //    var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

    //    await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
    //    {
    //        string uri=blobContainerClient.Uri.ToString();
    //        string name=blobItem.Name;
    //        var fullUri = $"{uri}/{name}";
    //        files.Add(new BlobDto
    //        {
    //            Name = name,
    //            Url = fullUri,
    //            ContentType = blobItem.Properties.ContentType
    //        });
    //    }
    //    return files;
    //}

    public async Task<BlobResponseDto> UploadAsync(IFormFile blob, string containerName)
    {
        var blobContainer = _blobServiceClient.GetBlobContainerClient(containerName);
        blobContainer.CreateIfNotExists(PublicAccessType.Blob);

        var file = blobContainer.GetBlobClient(blob.FileName);
        await using var data= blob.OpenReadStream();
        await file.UploadAsync(data, true);
        return new BlobResponseDto
        {
            IsSuccess = true,
            Message = $"{blob.FileName} uploaded successfully",
            Blob = new BlobDto
            {
                Name = blob.FileName,
                ContentType = blob.ContentType,
                Url = file.Uri.AbsoluteUri
            }
        };
    }
}
