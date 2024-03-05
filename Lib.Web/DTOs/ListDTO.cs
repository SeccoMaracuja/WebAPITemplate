namespace Lib.Web;

/// <summary>
/// The List DTO.
/// </summary>
public class ListDTO<T> where T : ModelBaseDTO
{
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    /// <value>The items.</value>
    public ICollection<T> Items { get; set; } = default!;

    /// <summary>
    /// Gets or sets the total count.
    /// </summary>
    /// <value>The total count.</value>
    public int TotalCount { get; set; }
}
