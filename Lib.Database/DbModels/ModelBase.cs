namespace Lib.Database;

/// <summary>
/// The model base.
/// </summary>
public abstract class ModelBase
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ModelBase"/> is removed.
    /// </summary>
    public bool Removed { get; set; }
}
