using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class OrderStore : IOrderStore
{
    public Task<Result> ChangeState(Guid guid, OrderStatus newStatus)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Order>> GetByFiltr(OrdersFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Order>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountWithFiltr(OrdersFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<Result<decimal>> GetLowerOrderPriceByFiltr(OrdersFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<Result<decimal>> GetMaxOrderPriceByFiltr(OrdersFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<Result<decimal>> GetMiddleOrderPriceByFiltr(OrdersFiltr filtr)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Order order)
    {
        throw new NotImplementedException();
    }
}
