using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Catalog.Domain.Primitives.Contracts;
 

namespace Shop.Catalog.Domain.Products
{
    public interface IProductRepository:IRepository<Product,Guid>
    {
        
    }
}