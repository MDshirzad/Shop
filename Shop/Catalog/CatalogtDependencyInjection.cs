using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Application.Product;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Infrastructure;
using Shop.Catalog.Infrastructure.Persistence;
using Shop.Middlewares.ExceptionHandler;

namespace Shop.Catalog
{
    public static class CatalogtDependencyInjection
    {
        public static void AddCatalogtDependencyInjection(
        this IServiceCollection services,IConfiguration configuration
    ){
            var assemblyType = Assembly.GetAssembly(typeof(Program));
            services.AddCarter();
            services.AddAutoMapper(assemblyType);
            //services.AddExceptionHandler<ExceptionHandler>();
            //services.AddProblemDetails();
           services.AddValidatorsFromAssembly(assemblyType);

             services.AddScoped<IProductRepository, ProductSqlRepository>();
             services.AddScoped<IProductManager, ProductManager>();
            var conf = configuration.GetConnectionString("Catalog");

            services.AddDbContext<CatalogContext>(options => {

                options.UseSqlServer(conf);

            });
        }



    }
}