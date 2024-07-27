using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Shop.Catalog.Domain;
namespace Shop.Catalog.Application.Dtos.Product
{
    public class ProductForCreationApplicationDto  
    {
        public string Name { get; set; }
       
        public string? Description { get; set; }
         
        public decimal Price { get; set; }
    }
}