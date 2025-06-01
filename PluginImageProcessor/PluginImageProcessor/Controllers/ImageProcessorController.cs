using Microsoft.AspNetCore.Mvc;
using PluginImageProcessor.Core;
using PluginImageProcessor.Core.Models.ResponseModels;
using PluginImageProcessor.Services.Interfaces;

namespace PluginImageProcessor.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ImageProcessorController : ControllerBase
{
    private readonly IImageProcessorService _service;

    public ImageProcessorController(IImageProcessorService service)
    {
        _service = service;
    }

    [HttpPost("process")]
    public async Task<IActionResult> ProcessImages([FromBody] List<ImageTask> tasks)
    {
        var response = await _service.ProcessTasks(tasks);
        return Ok(response);
    }
}
