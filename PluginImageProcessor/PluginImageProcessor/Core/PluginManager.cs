using PluginImageProcessor.Plugins;

namespace PluginImageProcessor.Core;

/// <summary>
/// Singleton that finds all IImageEffect implementations in loaded assemblies
/// and lets you create them by name.
/// </summary>
public class PluginManager
{
    private static PluginManager _instance;
    public static PluginManager Instance => _instance ??= new PluginManager();

    // Map plugin Name → Type
    private readonly Dictionary<string, Type> _plugins;

    private PluginManager()
    {
        _plugins = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

        // Scan all currently loaded assemblies
        var allTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a =>
            {
                try { return a.GetTypes(); }
                catch { return Array.Empty<Type>(); }
            });

        foreach (var t in allTypes)
        {
            if (typeof(IImageEffect).IsAssignableFrom(t)
                && !t.IsInterface
                && !t.IsAbstract)
            {
                // Instantiate an instance to read Name, or use ActivatorUtilities later.
                try
                {
                    var temp = (IImageEffect)Activator.CreateInstance(t);
                    var key = temp.Name;
                    if (!_plugins.ContainsKey(key))
                    {
                        _plugins[key] = t;
                    }
                    else
                    {
                        throw new Exception($"Duplicate plugin name '{key}' in {t.FullName}");
                    }
                }
                catch
                {
                    // If plugin has no parameterless ctor, skip it.
                }
            }
        }
    }

    /// <summary>
    /// Returns a new instance of the plugin whose Name matches effectName.
    /// </summary>
    public async Task<IImageEffect> Create(string effectName)
    {
        if (string.IsNullOrWhiteSpace(effectName))
            throw new ArgumentNullException(nameof(effectName));

        if (_plugins.TryGetValue(effectName, out var type))
        {
            return (IImageEffect)Activator.CreateInstance(type);
        }

        throw new KeyNotFoundException($"Plugin '{effectName}' not found.");
    }

    /// <summary>
    /// All registered plugin names (for validation or listing).
    /// </summary>
    public IEnumerable<string> GetAvailablePlugins() => _plugins.Keys;
}