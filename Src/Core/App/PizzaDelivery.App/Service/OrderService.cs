using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Domain.Logic;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Service;

public class OrderService
{
    private readonly OrdersAvailabiality _avaliability;
    private readonly IOrderStore _store;
    
    public OrderService(
        IOrderStore orderStore
        )
    {
        _store = orderStore;
        _avaliability = new(orderStore);
    }

    public async Task<Result<IReadOnlyList<Order>>> GetOrdersForUser(Guid UserId)
    {
        var UsersOrders = await _store.GetByFiltr(new OrdersFiltr(new List<Guid>(){UserId}, null, null));

        if(UsersOrders == null || UsersOrders.Count == 0)
        {
            return Result.Failure<IReadOnlyList<Order>>(new Error("11", "Dont Have Orders"));
        }

        return Result.Sucsesfull<IReadOnlyList<Order>>(UsersOrders);
    }

    public async Task<Result<decimal>> GetHightestPriceByDate(DateOnly date)
    {
        var filtr = new OrdersFiltr(null, [date], [OrderStatus.Complited]);

        var getMaxOrderPriseByDateResult = await _store.GetMaxOrderPriceByFiltr(filtr);

        if(getMaxOrderPriseByDateResult.IsSucsesfull == false)
        {
            return Result.Failure<decimal>(getMaxOrderPriseByDateResult.ErrorInfo);
        }

        return  getMaxOrderPriseByDateResult;
    }
    public async Task<Result<decimal>> GetMiddlePriceByDate(DateOnly date)
    {
        var filtr = new OrdersFiltr(null, [date], [OrderStatus.Complited]);

        var getMiddleOrderPriseByDateResult = await _store.GetMiddleOrderPriceByFiltr(filtr);

        if(getMiddleOrderPriseByDateResult.IsSucsesfull == false)
        {
            return Result.Failure<decimal>(getMiddleOrderPriseByDateResult.ErrorInfo);
        }

        return  getMiddleOrderPriseByDateResult;
    }

    public async Task<Result<decimal>> GetLowestPriceByDate(DateOnly date)
    {
        var filtr = new OrdersFiltr(null, [date], [OrderStatus.Complited]);

        var getMinOrderPriseByDateResult = await _store.GetLowerOrderPriceByFiltr(filtr);

        if(getMinOrderPriseByDateResult.IsSucsesfull == false)
        {
            return Result.Failure<decimal>(getMinOrderPriseByDateResult.ErrorInfo);
        }

        return  getMinOrderPriseByDateResult;
    }
    
    public async Task<Result<float>> GetPersentOfSucsessfullByUser(Guid guid)
    {
        var allEndedOrdersFiltr = new OrdersFiltr([guid], null, [OrderStatus.Canceled, OrderStatus.Complited]);
        var complitedFiltr = new OrdersFiltr([guid], null, [OrderStatus.Complited]);

        var allEndedCount = await _store.GetCountWithFiltr(allEndedOrdersFiltr);
        var complitedCount = await  _store.GetCountWithFiltr(complitedFiltr);

        if(allEndedCount == 0)
        {
            return Result.Failure<float>(new Error("123", "too low orders Info"));
        }

        return Result.Sucsesfull((float)complitedCount / (float)allEndedCount);
    }

    public async Task<Result<float>> GetPersentOfSucsessfullByDate(DateOnly dateOnly)
    {
        var allEndedOrdersFiltr = new OrdersFiltr(null, [dateOnly], [OrderStatus.Canceled, OrderStatus.Complited]);
        var complitedFiltr = new OrdersFiltr(null, [dateOnly], [OrderStatus.Complited]);

        var allEndedCount = await _store.GetCountWithFiltr(allEndedOrdersFiltr);
        var complitedCount = await  _store.GetCountWithFiltr(complitedFiltr);

        if(allEndedCount == 0)
        {
            return Result.Failure<float>(new Error("123", "too low orders Info"));
        }

        return Result.Sucsesfull((float)complitedCount / (float)allEndedCount);
    }

    public async Task<Result> Create(Order order)
    {
        var checkCreateOrderAvaliability = await _avaliability.CanCreateOrder(order);

        if(checkCreateOrderAvaliability.IsSucsesfull == false)
        {
            return Result.Failure(checkCreateOrderAvaliability.ErrorInfo);
        }

        var createOrderResult = await _store.Create(order);

        if(createOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(createOrderResult.ErrorInfo);
        }
        return Result.Sucsesfull();

    }

    public async Task<Result> Update(Order order)
    {
        var checkOrderChangeAvaliability = await _avaliability.AvaliabelOrder(order);

        if(checkOrderChangeAvaliability.IsSucsesfull == false)
        {
            return Result.Failure(checkOrderChangeAvaliability.ErrorInfo);
        }

        var updateOrderResult = await _store.Update(order);

        if(updateOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(updateOrderResult.ErrorInfo);
        }
        return Result.Sucsesfull();
    }

    public async Task<Result> CloseById(Guid Id)
    {
        var changeStateResult = await _store.ChangeState(Id, OrderStatus.Canceled);

        if(changeStateResult.IsSucsesfull == false)
        {
            //log
        }
        else
        {
            //log
        }

        return changeStateResult;
    }

    public async Task<int> GetCountOfCurrentActiveOrders()
    {
        var filtr = new OrdersFiltr(null, null, [OrderStatus.Awaited]);

        var getCountOfCurrentActiveOrders = await _store.GetCountWithFiltr(filtr);

        return getCountOfCurrentActiveOrders;

    }
    public async Task<int> GetOrdersCountByDate(DateOnly dateOnly)
    {
        var filtr = new OrdersFiltr(null, [dateOnly], [OrderStatus.Complited, OrderStatus.Awaited]);

        var ordersCount = await _store.GetCountWithFiltr(filtr);

        return ordersCount;

    }
    

}
