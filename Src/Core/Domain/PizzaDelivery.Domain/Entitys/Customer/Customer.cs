using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Customer
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public Phone Phone { get; init; }
}
