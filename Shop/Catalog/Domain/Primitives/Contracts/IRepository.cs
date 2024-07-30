using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Catalog.Application.Product.Queries;

namespace Shop.Catalog.Domain.Primitives.Contracts
{
    public interface IRepository<TEntity,TID> where TEntity:IEntity<TID> where TID: notnull
    {
        Task AddAsync(TEntity entity);
         Task<IReadOnlyList<TEntity>> GetAllAsync();
       Task<TEntity> GetByIdAsync(TID id);
       Task UpdateAsync(TEntity entity);
       Task DeleteAsync(TEntity entity);

       Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity,bool>> predicate);
        Task<PagedList<TEntity>> FilterAsync(QueryParams queryParams,string criteria);
        Task<PagedList<TEntity>> SearchAsync(QueryParams queryParams,string text);
        


    }
}