using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class CustomerOutputeObject
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string PhoneNumber { get; init; }
    
}
