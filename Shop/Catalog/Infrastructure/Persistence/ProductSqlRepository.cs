 
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Application.Product.Queries;
using Shop.Catalog.Domain.Products;
using System.Collections.Immutable;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace Shop.Catalog.Infrastructure.Persistence
{
    public class ProductSqlRepository : SqlRepository<Product, Guid>, IProductRepository
    {
        public ProductSqlRepository(CatalogContext context) : base(context)
        {
        }

        
        public override async Task<PagedList<Product>> SearchAsync(QueryParams queries, string? text)
        {
            var data = _set.AsNoTracking();
            if (!string.IsNullOrEmpty(text)) {

               
                data = data.Where(product =>
              EF.Functions.Like(product.Name, $"%{text}%")
              || EF.Functions.Like(product.Description, $"%{text}%")
          );

            
      
            }
            var result =await data.OrderByIf(queries.Sort).PagingAsync(queries.PageSize, queries.PageIndex);

            return result;
        }
    }
}