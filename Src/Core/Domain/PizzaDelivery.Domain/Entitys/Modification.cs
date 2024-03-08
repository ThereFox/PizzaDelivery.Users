using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Modification
{
    public int Id { get; private set; }
    public Ingridient ChangedIngridient { get; private set; }
    public decimal PriceChange { get; private set; }
    public int WeightChange { get; private set; }
}
