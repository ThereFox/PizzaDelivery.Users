using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Logic;

public class OrdersAvailabiality
{
    private IOrderStore _ordersStore;

    private const int MaxOrdersAtMoment = 10;
    private const int MaxCookedProductAtMoment = 25;
    private const decimal MinOrderPrice = 500;

    public OrdersAvailabiality(IOrderStore orderStore)
    {
        _ordersStore = orderStore;
    }

    public async Task<Result> CanCreateOrder(Order order)
    {
        if(resolwingProductPriceMoreThatLower(order) == false)
        {
            return Result.Failure(new Error("123", "prise low that mir order price"));
        }

        if(await haveTooManyOrdersAtMoment() && await haveTooManyAwaitedProductsWithNewOrder(order))
        {
            return Result.Failure(new Error("123", "have too many order"));
        }

        return Result.Sucsesfull();
    }

    public async Task<Result> AvaliabelOrder(Order order)
    {
        if(resolwingProductPriceMoreThatLower(order) == false)
        {
            return Result.Failure(new Error("123", "prise low that midl order price"));
        }

        if(await haveTooManyAwaitedProductsWithUpdatedOrder(order) == false)
        {
            return Result.Failure(new Error("123", "have too many ordered products"));
        }

        return Result.Sucsesfull();
    }

    private bool resolwingProductPriceMoreThatLower (Order order)
    {
        return order.FullPrice > MinOrderPrice;
    }
    private async Task<bool> haveTooManyOrdersAtMoment()
    {
        var activeFiltr = new OrdersFiltr(null, null, [OrderStatus.Awaited]);

        var countOfActiveOrders =  await _ordersStore.GetCountWithFiltr(activeFiltr);

        return countOfActiveOrders >= MaxOrdersAtMoment;
    }
    private async Task<bool> haveTooManyAwaitedProductsWithNewOrder(Order order)
    {
        var activeFiltr = new OrdersFiltr(null, null, [OrderStatus.Awaited]);

        var ActualOrders = await _ordersStore.GetByFiltr(activeFiltr);

        var countOfCookingProductsInActiveOrders = ActualOrders.Sum(ex => ex.Products.Count);

        var countOfProductInResolvingOrder = order.Products.Count;

        return countOfCookingProductsInActiveOrders + countOfProductInResolvingOrder > MaxCookedProductAtMoment;

    }
    private async Task<bool> haveTooManyAwaitedProductsWithUpdatedOrder(Order order)
    {
        var activeFiltr = new OrdersFiltr(null, null, [OrderStatus.Awaited]);

        var ActualOrders = await _ordersStore.GetByFiltr(activeFiltr);

        var countOfCookingProductsInActiveOrders = ActualOrders.Where(ex => ex.Id != order.Id).Sum(ex => ex.Products.Count);

        var countOfProductInResolvingOrder = order.Products.Count;

        return countOfCookingProductsInActiveOrders + countOfProductInResolvingOrder > MaxCookedProductAtMoment;

    }

}
