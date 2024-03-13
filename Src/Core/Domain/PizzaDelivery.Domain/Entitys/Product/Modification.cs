using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Modification
{
    public Guid Id { get; init; }
    public string Name { get; set; } = String.Empty;
    public Ingridient Ingridient { get; set; }
    public int Weight { get; set; } = 0;
    public decimal PriceChange { get; set; } = 0;
}
