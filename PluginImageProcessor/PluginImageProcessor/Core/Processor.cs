using PluginImageProcessor.Core.Models.ResponseModels;

namespace PluginImageProcessor.Core;

/// <summary>
/// Orchestrates processing a batch of ImageTask in sequence.
/// </summary>
public class Processor
{
    /// <summary>
    /// Process all images: for each ImageTask, simulate loading, apply each requested effect in order.
    /// </summary>
    public async Task<ApiResponseModel> ProcessAll(IEnumerable<ImageTask> tasks)
    {
        var results = new List<object>();

        foreach (var task in tasks)
        {
            Console.WriteLine($"\n--- Processing Image '{task.ImageId}' ---");

            var image = new ImageData(task.ImageId);
            var errors = new List<string>();

            foreach (var req in task.Effects)
            {
                try
                {
                    var plugin = await PluginManager.Instance.Create(req.EffectName);
                    plugin.Apply(image, req.Parameters);
                }
                catch (Exception ex)
                {
                    var err = $"[Error] Cannot apply effect '{req.EffectName}': {ex.Message}";
                    Console.WriteLine(err);
                    errors.Add(err);
                }
            }

            Console.WriteLine($"Finished '{task.ImageId}'. Effects run in order:");
            foreach (var logEntry in image.AppliedEffectsLog)
            {
                Console.WriteLine("  • " + logEntry);
            }

            results.Add(new
            {
                ImageId = task.ImageId,
                EffectsApplied = image.AppliedEffectsLog,
                Errors = errors
            });
        }

        return new ApiResponseModel(true, "Processing completed", results);
    }

}
