using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Filtrs;

namespace PizzaDelivery.Domain.Interfaces;

public interface IOrderStore
{
    public Task<IReadOnlyList<Order>> GetByFiltr(OrdersFiltr filtr);

    public Task<Result> Create(Order order);

    public Task<Result> Update(Order order);
    
}
