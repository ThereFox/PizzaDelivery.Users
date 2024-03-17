using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Authorization;

namespace PizzaDelivery.GraphQL.Auth.Attributes;

public class AnyAuthorise : AuthorizeAttribute
{
    public AnyAuthorise() : base("Any")
    {
        
    }
}
