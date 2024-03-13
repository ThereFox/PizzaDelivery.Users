using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys.Order;

public class OrderedProduct
{
    public Guid Id { get; set; }
    public Dictionary<Ingridient, int> ContainingIngridientsWeight { get; set; }
    public List<Modification> AppliedModification { get; set; }
    public int BaseWeight { get; set; }
    public decimal BasePrice { get; set; }
}
