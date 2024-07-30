 
using AutoMapper;
using Carter;
 
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
  
using Shop.Catalog.Application.Contracts.Dtos.Product;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Application.Product.Contracts.Dtos.Product;
using Shop.Catalog.Domain;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Presentation.Contracts.AsParameters;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;
using Shop.Catalog.Presentation.Contracts.Validators;
 
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace Shop.Catalog.Presentation.Endpoints
{
    public class ProductEndpoint(   ) : ICarterModule
    {
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            
            app.MapGet("product",GetAllProducts);
            app.MapGet("product/{id}",GetProduct);
            app.MapPost("product",CreateProduct);
            app.MapDelete("product/{id}",DeleteProduct);
           app.MapPut("product/{id}",UpdateProduct);
            app.MapGet("product/search", SearchProduct);

           
        }

        private async Task<IResult> SearchProduct( [FromQuery] string sort, [FromQuery] string text, [FromServices]IProductManager productManager,[FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
        {
            var result = await productManager.SearchAsync(new(sort,pageSize,pageIndex),text);
            if (result.IsSuccess)
            {
                return TypedResults.Ok( result.Value);
            }
            return TypedResults.BadRequest(result.Error);
        }

        private async Task<IResult> UpdateProduct(Guid id,[FromBody]ProductForUpdateDto product,[FromServices] IMapper mapper,[FromServices] IProductManager productManager)
        {

            var pm = mapper.Map<ProductForUpdateDto,ProductForUpdateDtoApplication>(product);
            var result = await productManager.UpdateProductAsync(id,pm);
             if(result.IsSuccess){
                var resultGet = await productManager.GetProductByIdAsync(id);
                return TypedResults.Ok(resultGet.Value);
             }
            
            return TypedResults.BadRequest(result.Error);
             
        }

        private async Task<IResult> DeleteProduct(Guid id,[FromServices] IProductManager productManager)
        { 
             var result = await productManager.DeleteProductAsync(id);
             if(result.IsSuccess){

                return Results.Ok();
             }
             return Results.BadRequest(result.Error);
        }

        private async Task<IResult> GetProduct(Guid id,[FromServices] IProductManager productManager)
        {
            var result = await productManager.GetProductByIdAsync(id);
            if(result.IsSuccess){
                return Results.Ok(result.Value);
            }
            return Results.Problem(result.Error);
       
        }

        private async Task<IResult> CreateProduct([AsParameters]CreateProductAsParameter createProductAsParameters, [FromServices] IProductManager productManager )
        {
            var product = createProductAsParameters.product;
            var validation = createProductAsParameters._CreationValidator.Validate(product);
            if(!validation.IsValid)
            {
                return Results.BadRequest(validation.Errors);
            }
            var map = createProductAsParameters._mapper.Map<ProductForCreationDto,ProductForCreationApplicationDto>(product);


            var result = await productManager.AddProductAsync(map);
            if (result.IsSuccess)
            {
                return TypedResults.Ok();

            }
            return Results.BadRequest(result.Error);
            
        }

        private async Task<IResult> GetAllProducts([FromServices]IProductManager productManager)
        {
            var result = await productManager.GetAllProducts();
            if (result.IsSuccess)
            {
            return TypedResults.Ok(result.Value);

            }
            return Results.BadRequest(result.Error);


        }
    }
}