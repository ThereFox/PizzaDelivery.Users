using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class Products
{
    public int Id { get; private set; }
    public int BaseWeight { get; private set; }
    public decimal BasePrice { get; private set; }
    public string Description { get; private set; }
    public bool IsArchived { get; private set; }

    public List<ProductIngridients> Ingridients { get; private set; }
    public List<OrderLists> OrderLists { get; private set; }
    public List<ProductModificationsInOrder> ModificationForThisProductsInOrders { get; private set; }
    public List<AvaliableModification> AvaliableModification { get; private set; }
    public List<ProductImage> ProductImages { get; private set; }
}
