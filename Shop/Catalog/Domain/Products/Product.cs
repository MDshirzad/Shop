using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Shop.Catalog.Domain.Primitives;

namespace Shop.Catalog.Domain.Products
{
    public class Product : Entity<Guid> 
    {
        
        public string Name { get; set; }=string.Empty;
       
        public string? Description { get; set; }
         
        public decimal Price { get; set; }
        public Product(Guid id, string name, decimal price,string description):base(id){

           
            Name = name;
            Description = description;
            Price = price;
        }

        public Product(Guid ID) : base(Guid.NewGuid())
        {
        }



    }
}