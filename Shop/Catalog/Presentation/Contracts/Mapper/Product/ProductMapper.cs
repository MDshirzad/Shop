using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Catalog.Application.Dtos.Product;
using Shop.Catalog.Presentation.Contracts.Dtos.Product;

namespace Shop.Catalog.Presentation.Contracts.Mapper.Product
{
    public class ProductMapper:Profile
    {
        public ProductMapper(){
           CreateMap<ProductForCreationApplicationDto ,ProductForCreationDto>();
        }
        
    }
}