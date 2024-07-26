using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Presentation.Contracts.Dtos.Product
{
    public record ProductForCreationDto(string Name,string Description,decimal Price);
}