using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Application.Product.Contracts.Dtos.Product
{
    public record  ProductForUpdateDtoApplication(string Name,decimal Price,string Description);
    
}