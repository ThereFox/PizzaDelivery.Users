using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

public class ProductInputObject
{
    [GraphQLNonNullType]
    public Guid Id { get; private set; }
    public List<Guid> ModificationIds { get; private set; }
}
