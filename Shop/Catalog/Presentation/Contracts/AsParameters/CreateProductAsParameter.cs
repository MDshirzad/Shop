using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;

namespace Shop.Catalog.Presentation.Contracts.AsParameters{

    public record CreateProductAsParameter([FromBody]ProductForCreationDto product,[FromServices] IValidator<ProductForCreationDto> _CreationValidator,[FromServices]  IMapper _mapper);

}