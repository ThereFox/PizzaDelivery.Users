using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISTUTimeTable.Src.Core.Common;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Domain.Interfaces;

namespace PizzaDelivery.App.Service;

public class OrderService
{
    private readonly IOrderStore _store;
    public OrderService(IOrderStore orderStore)
    {
        _store = orderStore;
    }

    public async Task<Result<IReadOnlyList<Order>>> GetOrdersForUser(Guid UserId)
    {
        var UsersOrders = _store.GetByFiltr(new OrdersFiltr(new List<Guid>(){UserId}, null, null));

        if(UsersOrders == null || UsersOrders.Count == 0)
        {
            return Result.Failure<IReadOnlyList<Order>>(new Error("11", "Dont Have Orders"));
        }

        return Result.Sucsesfull<List<Order>>(UsersOrders);
    }

}
