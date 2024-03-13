using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys.Order;

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public string Room { get; set; }
}
