using PluginImageProcessor.Core;

namespace PluginImageProcessor.Plugins;

/// <summary>
/// Every plugin/effect must implement this.
/// </summary>
public interface IImageEffect
{
    /// <summary>
    /// Unique name used to identify this plugin. Must match the name passed in EffectRequest.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Apply the effect to the given ImageData. 
    /// Parameters are provided in a dictionary; plugin picks the keys it expects.
    /// </summary>
    void Apply(ImageData image, IDictionary<string, object> parameters);
}
