using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

public class AddresInputObject
{
    [GraphQLNonNullType]
    public string City { get; init; }

    [GraphQLNonNullType]
    public string Street { get; init; }

    [GraphQLNonNullType]
    public string HouseNumber { get; init; }

    public string RoomNumber { get; init; }

}
