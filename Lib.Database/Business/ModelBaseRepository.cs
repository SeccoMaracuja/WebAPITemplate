using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Lib.Database;

/// <summary>
/// Model base repository.
/// </summary>
/// <typeparam name="TEntity">The entity.</typeparam>
public class ModelBaseRepository<TEntity>
    where TEntity : ModelBase
{
    /// <summary>
    /// The configuration.
    /// </summary>
    protected readonly IConfigurationProvider configuration;

    private readonly DbSet<TEntity> data;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModelBaseRepository{TEntity}" />
    /// class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="mapper">The mapper.</param>
    public ModelBaseRepository(DatabaseContext context, IMapper mapper)
    {
        data = context.Set<TEntity>();
        configuration = mapper.ConfigurationProvider;
    }

    /// <summary>
    /// Adds asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        return (await data.AddAsync(entity)).Entity;
    }

    /// <summary>
    /// Gets one item asynchronous.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="count">The count.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="orderBy">The order.</param>
    /// <param name="orderAscending">The order direction.</param>
    public async Task<(ICollection<T> Items, int TotalCount)> GetAsync<T>(
        int start, int count,
        Expression<Func<TEntity, bool>>? predicate = null,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool orderAscending = true)
    {
        var query = Get();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            if (orderAscending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
        }

        var totalCount = await query.CountAsync();
        var items = await query.AsSplitQuery().ProjectTo<T>(configuration).Skip(start).Take(count).ToListAsync();

        return (items, totalCount);
    }

    /// <summary>
    /// Gets multiple items asynchronous.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="orderBy">The order by.</param>
    /// <param name="orderAscending">if set to <c>true</c> [order ascending].</param>
    public async Task<IEnumerable<TEntity>> GetAsync(
      Expression<Func<TEntity, bool>>? predicate = null,
      Expression<Func<TEntity, object>>? orderBy = null,
      bool orderAscending = true
        )
    {
        var query = Get();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            if (orderAscending)
            {
                query = query.OrderBy(orderBy);
            }
            else
            {
                query = query.OrderByDescending(orderBy);
            }
        }
        return await query.ToListAsync();
    }

    /// <summary>
    /// Gets an item by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task<TEntity> GetByIdAsync(long id)
    {
        return await GetById(id).FirstOrDefaultAsync()
            ?? throw new KeyNotFoundException($"Entity {typeof(TEntity).Name} {id} not found.");
    }

    /// <summary>
    /// Softs delete asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public async Task<TEntity> SoftDeleteAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        entity.Removed = true;
        return entity;
    }

    /// <summary>
    /// Gets the instance.
    /// </summary>
    protected IQueryable<TEntity> Get()
    {
        return data.Where(x => !x.Removed);
    }

    /// <summary>
    /// Gets the instance by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    protected IQueryable<TEntity> GetById(long id)
    {
        return Get().Where(x => x.Id == id);
    }
}
