using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Domain.Primitives.Contracts
{
    public interface IRepository<TEntity,TID> where TEntity:IEntity<TID> where TID: notnull
    {
        Task AddAsync(TEntity entity);
         Task<IReadOnlyList<TEntity>> GetAllAsync();
     //   Task<TEntity> GetByIdAsync(TID id);
     //   Task UpdateAsync(TID id,TEntity entity);
     //   Task DeleteAsync(TEntity entity);


    }
}