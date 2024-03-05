using AutoMapper;

namespace Lib.Database;

/// <summary>
/// The Unit of work.
/// </summary>
public class UnitOfWork
{
    private readonly DatabaseContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="mapper">The mapper.</param>
    public UnitOfWork(DatabaseContext context, IMapper mapper)
    {
        this.context = context;
    }

    /// <summary>
    /// Saves the asynchronous.
    /// </summary>
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}
