namespace PluginImageProcessor.Core;

/// <summary>
/// Dummy representation of an image. In a real app, this might hold
/// pixel buffers or file paths. Here, we just track an ID and a log of "applied" effects.
/// </summary>
public class ImageData
{
    public string Id { get; }
    public List<string> AppliedEffectsLog { get; }

    public ImageData(string id)
    {
        Id = id;
        AppliedEffectsLog = new List<string>();
    }
}
