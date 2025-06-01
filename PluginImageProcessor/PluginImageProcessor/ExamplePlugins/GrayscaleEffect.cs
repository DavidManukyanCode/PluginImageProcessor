using PluginImageProcessor.Core;
using PluginImageProcessor.Plugins;

namespace PluginImageProcessor.ExamplePlugins;

/// <summary>
/// Dummy "grayscale" effect. No parameters needed.
/// </summary>
public class GrayscaleEffect : IImageEffect
{
    public string Name => "Grayscale";

    public void Apply(ImageData image, IDictionary<string, object> parameters)
    {
        image.AppliedEffectsLog.Add("Convert to Grayscale");
        System.Console.WriteLine($"[GrayscaleEffect] Image '{image.Id}' → converted to grayscale (simulated).");
    }
}
