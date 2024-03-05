namespace Lib.Web;

/// <summary>
/// The Model base dto.
/// </summary>
public abstract class ModelBaseDTO
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ModelBaseDTO" /> is
    /// removed.
    /// </summary>
    /// <value><c>true</c> if removed; otherwise, <c>false</c>.</value>
    public bool Removed { get; set; }
}
