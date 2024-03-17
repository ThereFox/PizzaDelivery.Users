using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Ingridient
{
    public Guid Id { get; init; }
    public string Name { get; set; }
}
