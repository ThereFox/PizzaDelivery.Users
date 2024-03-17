using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class OrderStatus
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool isEnded { get; private set;}

    public List<Orders> OrdersWithThisStatus { get; private set;}
}
