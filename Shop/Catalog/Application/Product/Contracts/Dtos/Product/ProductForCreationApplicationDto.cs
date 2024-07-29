using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
 
using Shop.Catalog.Domain;
namespace Shop.Catalog.Application.Contracts.Dtos.Product
{
    public class ProductForCreationApplicationDto  
    {
        public required string Name { get; set; }
       
        public string? Description { get; set; }
         
        public required decimal Price { get; set; }
    }
}