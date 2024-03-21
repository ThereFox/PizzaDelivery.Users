using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Dictionary<Ingridient, int> ContainingIngridientsWeight { get; set; }
    public List<Modification> AvaliableModification { get; set; }
    public int Weight { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set;}
    public bool IsArchived { get; set; }
}
