using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

public class AddresInputObject
{
    [GraphQLNonNullType]
    public string City { get; private set; }

    [GraphQLNonNullType]
    public string Street { get; private set; }

    [GraphQLNonNullType]
    public string HouseNumber { get; private set; }

    public string RoomNumber { get; private set; }

}
