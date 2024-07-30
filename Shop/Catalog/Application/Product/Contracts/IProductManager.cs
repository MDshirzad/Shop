using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Shop.Catalog.Application.Contracts.Dtos.Product;
using Shop.Catalog.Application.Product.Contracts.Dtos.Product;
using Shop.Catalog.Application.Product.Queries;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;

namespace Shop.Catalog.Application.Product.Contracts
{
    public interface IProductManager
    { 
    Task<Result> AddProductAsync(ProductForCreationApplicationDto productForAddDto);
    Task<Result> UpdateProductAsync(Guid productId, ProductForUpdateDtoApplication productForUpdateDto);
   Task<Result> DeleteProductAsync(Guid productId);
 Task<Result< Domain.Products.Product> > GetProductByIdAsync(Guid productId);
  Task<Result<IReadOnlyList<Domain.Products.Product>>> GetAllProducts( );

Task<Result<PagedList<Domain.Products.Product>>> FilterAsync( QueryParams data,string? criteria);
Task<Result<PagedList<Domain.Products.Product>>> SearchAsync( QueryParams data,string? text);
    }
}