using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class OrderLists
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int ProductId { get; private set; }

    public Orders Order { get; private set; }
    public Products Product {get; private set; }
    public List<ProductModificationsInOrder> Modifications { get; private set; }
}
