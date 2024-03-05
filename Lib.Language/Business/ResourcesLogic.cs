using System.Reflection;
using System.Resources;

namespace Lib.Language;

/// <summary>
/// The resources logic.
/// </summary>
public class ResourcesLogic
{
    /// <summary>
    /// Gets the string.
    /// </summary>
    /// <param name="key">The key.</param>
    public string GetString(string key)
    {
        ResourceManager rm = new ResourceManager("Lib.Language.Resources", Assembly.GetExecutingAssembly());

        return rm.GetString(key) ?? key;
    }
}
