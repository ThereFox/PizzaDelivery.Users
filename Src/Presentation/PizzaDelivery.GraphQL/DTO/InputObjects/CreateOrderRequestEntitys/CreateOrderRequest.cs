using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class CreateOrderRequest
{
    [GraphQLNonNullType]
    public List<ProductInputObject> Products { get; set;}
    [GraphQLNonNullType]
    public AddresInputObject Addres { get; private set; }
    
    public string Comment { get; private set; }
}
