using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Shop.Catalog.Domain;
namespace Shop.Catalog.Application.Dtos.Product
{
    public class ProductForCreationApplicationDto : Catalog.Domain.Product
    {
        public ProductForCreationApplicationDto(Guid ID) : base(ID)
        {
        }
    }
}