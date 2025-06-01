using PluginImageProcessor.Core.Models.RequestModels;

namespace PluginImageProcessor.Core;

/// <summary>
/// One “job” for one image: its ID (or file path) and the list of effects to run.
/// </summary>
public class ImageTask
{
    public string ImageId { get; set; }
    public List<EffectRequest> Effects { get; set; } = new List<EffectRequest>();
}
