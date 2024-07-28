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
        
        public string Name { get; private set; }=string.Empty;
       
        public string? Description { get;  set; }
         
        public decimal Price { get; private set; }
        public Product( string name, decimal price,string description):base(Guid.NewGuid()){

           
            Name = name;
            Description = description;
            Price = price;
        }

        public Product() : base(Guid.NewGuid())
        {
        }


        public void ChangeName(string nName)=> this.Name=nName;
        public void ChangePrice(decimal nPrice)=> this.Price=nPrice;
        public void ChangeDescription(string description)=>this.Description=description;


    }
}