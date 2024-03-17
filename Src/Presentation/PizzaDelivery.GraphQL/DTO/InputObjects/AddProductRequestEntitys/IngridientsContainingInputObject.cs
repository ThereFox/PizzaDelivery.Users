using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects.AddProductRequestEntitys;

public class IngridientsContainingInputObject
{
    [GraphQLNonNullType]
    public Guid IngridientId { get; private set; }
    [GraphQLNonNullType]
    public int NormalWeight { get; private set; }
}
