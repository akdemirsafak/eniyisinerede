using File.API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Controllers;

namespace File.API.Controllers;

public class ImageController(IFileService _fileService) : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile image)
    {

        return CreateActionResult(await _fileService.UploadAsync(image, "images"));

    }
    [HttpDelete]
    public async Task<IActionResult> Delete(string fileName)
    {
        return CreateActionResult(await _fileService.DeleteAsync(fileName, "images"));
    }
}
