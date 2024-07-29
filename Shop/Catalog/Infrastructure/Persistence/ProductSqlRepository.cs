 
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Domain.Products;



namespace Shop.Catalog.Infrastructure.Persistence
{
    public class ProductSqlRepository : SqlRepository<Product, Guid>, IProductRepository
    {
        public ProductSqlRepository(CatalogContext context) : base(context)
        {
        }
    }
}