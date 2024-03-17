using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class OrderOutputeObject
{
    public List<ProductOutputeObject> Products { get; private set; }
    public PublicAddressOutputeObject Address { get; private set; }
}
