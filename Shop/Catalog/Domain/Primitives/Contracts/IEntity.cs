using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Catalog.Domain.Primitives.Contracts
{
    public interface IEntity<TID>  where TID: notnull
    {
        TID ID { get;}
    }
}