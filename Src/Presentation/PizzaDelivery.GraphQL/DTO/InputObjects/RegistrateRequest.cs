using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class RegistrateRequest
{
    [GraphQLNonNullType]
    public string PhoneNumber { get; private set; }
    [GraphQLNonNullType]
    public string Name { get; private set; }
    [GraphQLNonNullType]
    public string password { get; private set; }
}
