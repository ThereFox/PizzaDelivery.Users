using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class AuthoriseRequest
{
    [GraphQLNonNullType]
    public string PhoneNumber { get; private set; }
    [GraphQLNonNullType]
    public string Password { get; private set; }
}
