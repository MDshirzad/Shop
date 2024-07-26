using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Catalog.Domain.Primitives.Contracts;

namespace Shop.Catalog.Domain.Primitives
{
    public class Entity<TID> : IEntity<TID> where TID : notnull
    {
        public TID ID {get;init;}
        public Entity(TID ID){
            this.ID = ID;
        }
    }
}