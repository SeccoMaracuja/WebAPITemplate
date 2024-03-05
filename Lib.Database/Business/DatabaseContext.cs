using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lib.Database;

/// <summary>
/// Database context.
/// </summary>
public class DatabaseContext : IdentityDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// <para>
    /// Override this method to configure the database (and other options) to be used
    /// for this context. This method is called for each instance of the context that
    /// is created. The base implementation does nothing.
    /// </para>
    /// <para>
    /// In situations where an instance of <see
    /// cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have
    /// been passed to the constructor, you can use <see
    /// cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" />
    /// to determine if the options have already been set, and skip some or all of the
    /// logic in <see
    /// cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)"
    /// />.
    /// </para>
    /// </summary>
    /// <param name="optionsBuilder">
    /// A builder used to create or modify options for this context. Databases (and
    /// other extensions) typically define extension methods on this object that allow
    /// you to configure the context.
    /// </param>
    /// <remarks>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime,
    /// configuration, and initialization</see> for more information.
    /// </remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();

        base.OnConfiguring(optionsBuilder);
    }
}
