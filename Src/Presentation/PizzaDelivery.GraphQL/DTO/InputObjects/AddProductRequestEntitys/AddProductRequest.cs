using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using PizzaDelivery.GraphQL.DTO.InputObjects.AddProductRequestEntitys;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class AddProductRequest
{
    [GraphQLNonNullType]
    public List<IngridientsContainingInputObject> IngridientsContaining { get; private set; }
    
    [GraphQLNonNullType]
    public decimal Price { get; private set;}
    
    [GraphQLNonNullType]
    public string Description { get; private set; }
    
    public bool IsStartInArchive { get; private set; } = true;
}
