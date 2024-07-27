using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Application.Product;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Infrastructure;
using Shop.Catalog.Infrastructure.Persistence;

namespace Shop.Catalog
{
    public static class ProductDependencyInjection
    {
        public static void AddProductDependencyInjection(
        this IServiceCollection services,IConfiguration configuration
    ){
         services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<IProductRepository, ProductSqlRepository>(); 
      
        var conf = configuration.GetConnectionString("Catalog");
        Console.WriteLine(conf);
services.AddDbContext<CatalogContext>(options =>{

 options.UseSqlServer(conf);

});
    }



    }
}