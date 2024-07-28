using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using Shop.Catalog.Application.Contracts.Dtos.Product;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Application.Product.Contracts.Dtos.Product;
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
        public async Task<Result> AddProductAsync(ProductForCreationApplicationDto productForAddDto)
        {
            try
            {
                Domain.Products.Product product= new(productForAddDto.Name,productForAddDto.Price,productForAddDto.Description);
           await productRepository.AddAsync(product);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Error:{ex.Message}");
                 
            }
       
        }

        public async Task<Result> DeleteProductAsync(Guid productId)
        {
         try{
           var resultGet  = await productRepository.GetByIdAsync(productId);
           if(resultGet is  null ){
            return Result.Failure($"Product {productId} Not Found");
           }
             await productRepository.DeleteAsync(resultGet);
            return Result.Success("OK");
            }catch(Exception ex){
              return  Result.Failure<IReadOnlyList<Domain.Products.Product>>($"Error:{ex.Message}");
            }
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

        public async Task<Result<  Domain.Products.Product> > GetProductByIdAsync(Guid productId)
        {
           try{

              var response = await productRepository.GetByIdAsync(productId);
              return Result.Success(response );
           }catch(Exception ex){
              return Result.Failure<  Domain.Products.Product> (ex.Message);
           } 
        }

        public async Task<Result> UpdateProductAsync(Guid productId, ProductForUpdateDtoApplication productForUpdateDto)
        {
            try{
            var product = await productRepository.GetByIdAsync(productId);
            if(product is null){
                return Result.Failure($"Product {productId} Not Found");
            }
            product.ChangeName(productForUpdateDto.Name);
            product.ChangeDescription(productForUpdateDto.Description);
            product.ChangePrice(productForUpdateDto.Price);

            await productRepository.UpdateAsync(product);

            return Result.Success();
}catch(Exception ex){
        return Result.Failure($"Error On Update Product:{ex.Message}");
}
        }
    }
}