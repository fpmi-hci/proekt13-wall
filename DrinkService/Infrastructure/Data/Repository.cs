using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Infrastructure.Interfaces;
using Infrastructure.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Data;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    protected DrinkServiceDbContext Context { get; }

    public Repository(DrinkServiceDbContext context)
    {
        Context = context;
    }

    public ValueTask<TEntity> GetById(TKey key)
    {
        return Context.FindAsync<TEntity>(key);
    }

    public Task<ReadOnlyCollection<TEntity>> Query(Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
    {
        var query = Context.Set<TEntity>().AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        return Task.FromResult(new ReadOnlyCollection<TEntity>(query.ToList()));
    }

    public IQueryable<TEntity> GetQuery(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        var query = Context.Set<TEntity>().AsNoTracking();

        if (include is not null)
        {
            query = include(query);
        }

        return query;
    }

    public async Task<int> Insert(TEntity entity)
    {
        Context.Add(entity);

        return await Context.SaveChangesAsync();
    }

    public async Task<int> Update(TEntity entity)
    {
        Context.Update(entity);

        return await Context.SaveChangesAsync();
    }

    public async Task<int> Delete(TEntity entity)
    {
        Context.Remove(entity);

        return await Context.SaveChangesAsync();
    }

    public void Detach(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Detached;
    }
}