using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;
using Shop.Catalog.Presentation.Contracts.Validators;

namespace Shop.Catalog.Presentation.Endpoints
{
    public class ProductEndpoint : ICarterModule
    {
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            
            app.MapGet("product",GetAllProducts);
            app.MapGet("product/{id}",GetProduct);
            app.MapPost("product",CreateProduct);
            app.MapDelete("product/{id}",DeleteProduct);
            app.MapPut("product/{id}",UpdateProduct);

           
        }
        public record Product(string Name,decimal Price);

        private async Task<IResult> UpdateProduct(int id,[FromBody]Product Product)
        {

            
             return   TypedResults.Ok( await Task.FromResult(Product));
        }

        private async Task<IResult> DeleteProduct(int id)
        { 
             return   TypedResults.Ok( await Task.FromResult(0));
        }

        private async Task<IResult> GetProduct(int id)
        {
           return   TypedResults.Ok( await Task.FromResult(0));
        }

        private async Task<IResult> CreateProduct([FromBody]ProductForCreationDto Product,[FromServices] IValidator<ProductForCreationDto> _CreationValidator)
        {
            var validation = _CreationValidator.Validate(Product);
            if(!validation.IsValid)
            {
                return Results.BadRequest(validation.Errors);
            }
             return   TypedResults.Ok( await Task.FromResult(Product));
        }

        private async Task<IResult> GetAllProducts()
        {
           return   TypedResults.Ok( await Task.FromResult(0));
        }
    }
}