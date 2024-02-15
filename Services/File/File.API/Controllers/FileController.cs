using File.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace File.API.Controllers;

public class FileController(IFileService _fileService) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        return CreateActionResult(await _fileService.UploadAsync(file, "files"));
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string fileName)
    {
        return CreateActionResult(await _fileService.DeleteAsync(fileName, "files"));
    }
    [HttpPost]
    public async Task<IActionResult> Download(string fileName, string containerName)
    {
        var response = await _fileService.DownloadAsync(fileName, containerName);
        return CreateActionResult(await _fileService.DownloadAsync(fileName,containerName));
    }
}
