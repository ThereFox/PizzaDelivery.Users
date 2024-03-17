using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class CustomerOutputeObject
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
}
