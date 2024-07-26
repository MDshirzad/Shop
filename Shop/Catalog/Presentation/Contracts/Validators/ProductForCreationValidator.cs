using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;

namespace Shop.Catalog.Presentation.Contracts.Validators
{
    public class ProductForCreationValidator:AbstractValidator<ProductForCreationDto>
    {
        public  ProductForCreationValidator()
        {
            RuleFor(x=>x.Name)
            .NotEmpty()
            .NotNull();
             

            RuleFor(x=>x.Price)
            .GreaterThan(0)
            .NotEmpty()
            .NotNull();

        }
    }
}