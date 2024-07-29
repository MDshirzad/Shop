using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Catalog.Domain;
using Shop.Catalog.Domain.Products;


namespace Shop.Catalog.Infrastructure
{
    public class CatalogContext :DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options):base(options){
            
        }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

      public DbSet<Product> Products => Set<Product>();
    }
}