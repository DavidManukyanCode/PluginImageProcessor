namespace PluginImageProcessor.Core.Models.RequestModels;

/// <summary>
/// Represents a single effect name + its parameters.
/// </summary>
public class EffectRequest
{
    /// <summary>
    /// The unique plugin name (must match IImageEffect.Name).
    /// </summary>
    public string EffectName { get; set; }

    /// <summary>
    /// Zero or more key/value parameters. Plugin reads what it needs.
    /// </summary>
    public IDictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
}
