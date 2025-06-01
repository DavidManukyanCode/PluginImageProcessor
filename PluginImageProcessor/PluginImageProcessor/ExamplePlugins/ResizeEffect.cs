using PluginImageProcessor.Core;
using PluginImageProcessor.Plugins;

namespace PluginImageProcessor.ExamplePlugins;
/// <summary>
/// Dummy "resize" effect. Expects parameter "width" (int).
/// </summary>
public class ResizeEffect : IImageEffect
{
    public string Name => "Resize";

    public void Apply(ImageData image, IDictionary<string, object> parameters)
    {
        // Read a "width" parameter (fallback to 100 if missing)
        int width = 100;
        if (parameters != null && parameters.ContainsKey("width"))
        {
            try
            {
                width = Convert.ToInt32(parameters["width"]);
            }
            catch
            {
                // invalid, keep default
            }
        }

        // Simulate resizing
        image.AppliedEffectsLog.Add($"Resize to {width}px");
        Console.WriteLine($"[ResizeEffect] Image '{image.Id}' → resized to {width}px (simulated).");
    }
}
