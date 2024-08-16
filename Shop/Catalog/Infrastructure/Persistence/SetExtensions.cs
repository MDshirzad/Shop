using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Application.Product.Queries;
using System.Collections.Immutable;
using System.Linq.Dynamic.Core;

namespace Shop.Catalog.Infrastructure.Persistence{
public static class SetExtensions{
  public static IQueryable<TEntity> WhereIf<TEntity>(
      this IQueryable<TEntity> query,
      string? criteria
  )
  {
      if (!string.IsNullOrEmpty(criteria))
      {
          query = query.Where(criteria);
      }

      return query;
  }

    public static IQueryable<TEntity> OrderByIf<TEntity>(
      this IQueryable<TEntity> query,
      string? sort
  )
  {
      if (!string.IsNullOrEmpty(sort))
      {
          query = query.OrderBy(sort);
      }

      return query;
  }


   public static async Task<PagedList<TEntity>> PagingAsync<TEntity>(
     this IQueryable<TEntity> query,
     int pageSize,
     int pageIndex
 )
 {
     var totalRecordCount = await query.CountAsync();

     var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

     return new PagedList<TEntity>(result.ToImmutableList(), totalRecordCount);
 }




}


}