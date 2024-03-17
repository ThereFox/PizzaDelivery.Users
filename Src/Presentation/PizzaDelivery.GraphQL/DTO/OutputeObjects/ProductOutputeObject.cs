using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class ProductOutputeObject
{
    public List<Ingridient> Ingridients { get; private set; }
    public List<Modification> AvaliableModification { get; set; }
    public int Weight { get; set; }
    public decimal Price { get; set; }
}
