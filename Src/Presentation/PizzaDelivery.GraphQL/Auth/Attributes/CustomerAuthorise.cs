using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Authorization;

namespace PizzaDelivery.GraphQL.Auth.Attributes;

internal class CustomerAuthorise : AuthorizeAttribute
{
    internal CustomerAuthorise() : base("CustomerAuthorise")
    {
        this.Roles = ["Customer"];
    }
}
