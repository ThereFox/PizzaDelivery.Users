using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.Domain.Entitys.Order;

public class Order
{
    public Guid Id { get; init; }
    public Customer Customer { get; set; }
    public List<OrderedProduct> Products { get; set; }
    public DateTime OrderTime { get; set; }
    public DateTime DeliveryTime { get; set; }
    public DateTime AwaitedDeliveryTime { get; set; }
    public Address Address { get; set; }
    public string Comment { get; set; }
    public OrderStatus Status { get; set; }

}
