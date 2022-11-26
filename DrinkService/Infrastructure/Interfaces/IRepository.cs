using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Infrastructure.Model.Base;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
{
    ValueTask<TEntity> GetById(TKey key);

    Task<ReadOnlyCollection<TEntity>> Query(
        Expression<Func<TEntity, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

    IQueryable<TEntity> GetQuery(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    Task<int> Insert(TEntity entity);

    Task<int> Update(TEntity entity);

    Task<int> Delete(TEntity entity);

    void Detach(TEntity entity);
}