using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Authorization;

namespace PizzaDelivery.GraphQL.Auth.Attributes;

public class AdminAuthorise : AuthorizeAttribute
{
    public AdminAuthorise() : base("Administration")
    {
        this.Roles = ["Admin"];
    }
}
