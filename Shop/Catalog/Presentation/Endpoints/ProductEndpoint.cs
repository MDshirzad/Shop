using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shop.Catalog.Application.Contracts.Dtos.Product;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Domain;
using Shop.Catalog.Presentation.Contracts.AsParameters;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;
using Shop.Catalog.Presentation.Contracts.Validators;

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
          //  app.MapPut("product/{id}",UpdateProduct);

           
        }
     

        // private async Task<IResult> UpdateProduct(int id,[FromBody]Product Product)
        // {
    
             

            
        //      return   TypedResults.Ok( await Task.FromResult(Product));
        // }

        private async Task<IResult> DeleteProduct(int id)
        { 
             return   TypedResults.Ok( await Task.FromResult(0));
        }

        private async Task<IResult> GetProduct(int id)
        {


           return TypedResults.Accepted("");
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