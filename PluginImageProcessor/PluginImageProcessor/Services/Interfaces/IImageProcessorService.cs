using PluginImageProcessor.Core;
using PluginImageProcessor.Core.Models.ResponseModels;

namespace PluginImageProcessor.Services.Interfaces;

public interface IImageProcessorService
{
    Task<ApiResponseModel> ProcessTasks(IEnumerable<ImageTask> tasks);
}