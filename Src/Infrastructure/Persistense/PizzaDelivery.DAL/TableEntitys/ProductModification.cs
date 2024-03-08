using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class ProductModifications
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int IngridientId { get; private set; }
    public decimal PriceChange { get; private set; }
    public int WeightChange { get; private set; }

    public Ingridients Ingridient { get; private set; }
    public List<AvaliableModification> AvaliableForProducts { get; private set; }
    public List<ProductModificationsInOrder> OrdersWithThisModification { get; private set; }

}
