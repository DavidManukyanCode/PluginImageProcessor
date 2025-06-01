using PluginImageProcessor.Core;
using PluginImageProcessor.Plugins;

namespace PluginImageProcessor.ExamplePlugins;

/// <summary>
/// Dummy "blur" effect. Expects parameter "radius" (int).
/// </summary>
public class BlurEffect : IImageEffect
{
    public string Name => "Blur";

    public void Apply(ImageData image, IDictionary<string, object> parameters)
    {
        int radius = 5;
        if (parameters != null && parameters.ContainsKey("radius"))
        {
            try
            {
                radius = Convert.ToInt32(parameters["radius"]);
            }
            catch
            {
                // invalid, keep default
            }
        }

        image.AppliedEffectsLog.Add($"Blur radius {radius}");
        Console.WriteLine($"[BlurEffect] Image '{image.Id}' → blur radius {radius}px (simulated).");
    }
}
