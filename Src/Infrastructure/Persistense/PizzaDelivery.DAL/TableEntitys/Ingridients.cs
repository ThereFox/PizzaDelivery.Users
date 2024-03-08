using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class Ingridients
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public List<ProductIngridients> ProductIngridients { get; private set; }
    public List<ProductModifications> ModificationsWithThisIngridients { get; private set; }
}
