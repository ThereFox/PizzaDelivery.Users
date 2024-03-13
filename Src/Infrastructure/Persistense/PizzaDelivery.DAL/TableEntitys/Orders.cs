using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class Orders
{
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public DateTime OrderTime { get; private set; }
    public DateTime DeliveryTime { get; private set; }
    public DateTime AwaitedTime { get; private set; }

    public string CommentForDelivery { get; private set; }

    public int AddresId { get; private set; }
    public int FeedBackId { get; private set; }
    public int StatusId { get; private set; }

    public Customers Customer { get; private set; }
    public List<OrderLists> OrderElements { get; private set; }
    public OrderFeedbacks Feedback { get; private set; }
    public Addreses Addres { get; private set; }
    public OrderStatus Status { get; private set; }
}
