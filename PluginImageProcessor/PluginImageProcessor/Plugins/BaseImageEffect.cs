using PluginImageProcessor.Core;

namespace PluginImageProcessor.Plugins;

/// <summary>
/// If you have shared helpers or logging, put them here. 
/// Not strictly required, but can hold common utilities.
/// </summary>
public abstract class BaseImageEffect : IImageEffect
{
    public abstract string Name { get; }

    public void Apply(ImageData image, IDictionary<string, object> parameters)
    {
        // Optional: common pre-checks
        if (image == null) throw new ArgumentNullException(nameof(image));
        // Let concrete plugin do the work
        ApplyEffect(image, parameters);
        // Optional: common post-logic (e.g. logging)
    }

    protected abstract void ApplyEffect(ImageData image, IDictionary<string, object> parameters);
}