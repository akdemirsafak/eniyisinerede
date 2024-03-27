using File.API.Services;
using File.API.Utilities;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;
namespace File.API.Controllers;

public class FileController(IFileService _fileService) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        return CreateActionResult(await _fileService.UploadAsync(file, BlobContainerNameConstants.Files));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string fileName)
    {
        return CreateActionResult(await _fileService.DeleteAsync(fileName, BlobContainerNameConstants.Files));
    }
    [HttpPost("download")]
    public async Task<IActionResult> Download(string fileName)
    {
        var response = await _fileService.DownloadAsync(fileName, BlobContainerNameConstants.Files);
        return CreateActionResult(await _fileService.DownloadAsync(fileName, BlobContainerNameConstants.Files));
    }
}
