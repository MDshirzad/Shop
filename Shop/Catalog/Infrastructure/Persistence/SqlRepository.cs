using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Application.Product.Queries;
using Shop.Catalog.Domain.Primitives;
using Shop.Catalog.Domain.Primitives.Contracts;

namespace Shop.Catalog.Infrastructure.Persistence
{
    public abstract class  SqlRepository<TEntity, TId> :IDisposable,
     IRepository<TEntity, TId> where TEntity :
      Entity<TId> where TId : notnull
    {
    public virtual async void Dispose()
        { 
           await _context.DisposeAsync();
             
        }
        
    protected SqlRepository(DbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }
       private readonly DbContext _context;
        protected DbSet<TEntity> _set;
        public async Task AddAsync(TEntity entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteAsync(TEntity entity)
        {
           _set.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id) => await  _set.FindAsync(id);         

        public async Task UpdateAsync( TEntity entity)
        {
          _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            var result =await _set.ToListAsync();
           return result.ToImmutableList();
        }
        
  public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
  {
      var result = await _set.Where(predicate).ToListAsync();

      return result.ToImmutableList();
  }

  public async Task<PagedList<TEntity>> FilterAsync(QueryParams queries,string? criteria)
  {
      var result = await _set.AsNoTracking()
          .WhereIf(criteria)
          .OrderByIf(criteria)
          .PagingAsync(queries.PageSize, queries.PageIndex);

      return result;
  }

  public abstract Task<PagedList<TEntity>> SearchAsync(QueryParams queries,string? text);
        
    }
}