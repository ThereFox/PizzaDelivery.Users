using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class ProductIngridients
{
    public int Id { get; private set; }
    public int ProductId { get; private set; }
    public int IngridientId { get; private set; }
    public int Weight { get; private set; }

    public Products Product { get; private set; }
    public Ingridients Ingridient { get; private set; }
}
