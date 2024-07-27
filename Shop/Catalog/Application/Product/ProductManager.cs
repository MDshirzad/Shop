using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;

namespace Shop.Catalog.Application.Product
{
    public class ProductManager : IProductManager
    {
        IProductRepository productRepository;
        public ProductManager(IProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
            
        }
        public Task<Result> AddProductAsync(ProductForCreationDto productForAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteProductAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IReadOnlyList<Domain.Products.Product>>> GetAllProducts()
        {
            try{
           var result  = await productRepository.GetAllAsync();
            return Result.Success(result);
            }catch(Exception ex){
              return  Result.Failure<IReadOnlyList<Domain.Products.Product>>("Error");
            }
           
        }

        //public async Task<Result<  Domain.Products.Product> > GetProductByIdAsync(Guid productId)
        //{
        //    //try{

        //    //    var response = await productRepository.GetByIdAsync(productId);
        //    //    return Result.Success(response );
        //    //}catch(Exception ex){
        //    //    return Result.Failure<  Domain.Products.Product> (ex.Message);
        //    //} 
        //}
 
    }
}