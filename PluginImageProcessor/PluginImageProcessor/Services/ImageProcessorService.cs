using PluginImageProcessor.Core;
using PluginImageProcessor.Core.Models.ResponseModels;
using PluginImageProcessor.Services.Interfaces;

namespace PluginImageProcessor.Services;
public class ImageProcessorService : IImageProcessorService
{
    private readonly Processor _processor;

    public ImageProcessorService()
    {
        _processor = new Processor();
    }

    public async Task<ApiResponseModel> ProcessTasks(IEnumerable<ImageTask> tasks)
    {
         return await _processor.ProcessAll(tasks);
    }
}
