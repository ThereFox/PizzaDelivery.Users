using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Product
{
    public int Id { get; private set; }
    public List<Ingridient> Ingridients { get; private set; }
    public List<Modification> Modifications { get; private set; }
    public int BaseWeight { get; private set; }
    public decimal BasePrice { get; private set; }
    public string Descriptions { get; private set; }

    public decimal Price
    {
        get
        {
            return BasePrice + Modifications.Sum(ex => ex.PriceChange);
        }
    }
    public decimal Weight
    {
        get
        {
            return BaseWeight + Modifications.Sum(ex => ex.WeightChange);
        }
    }

}
