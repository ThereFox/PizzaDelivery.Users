using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ordering;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Interfaces;

public interface IOrderStore
{
    public Task<Result<Order>> GetById(Guid id);

    public Task<IReadOnlyList<Order>> GetByFiltr(OrdersFiltr filtr);

    public Task<Result<decimal>> GetMaxOrderPriceByFiltr(OrdersFiltr filtr);
    public Task<Result<decimal>> GetMiddleOrderPriceByFiltr(OrdersFiltr filtr);
    public Task<Result<decimal>> GetLowerOrderPriceByFiltr(OrdersFiltr filtr);

    public Task<int> GetCountWithFiltr(OrdersFiltr filtr);


    public Task<Result> Create(Order order);

    public Task<Result> Update(Order order);
    
}
