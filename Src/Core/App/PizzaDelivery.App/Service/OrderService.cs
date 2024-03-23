using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.DAL.Interfaces;
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
    private readonly ICurrentCustomerInfoGetter _currentService;
    private readonly ICustomerStore _customerStore;
    
    public OrderService(
        IOrderStore orderStore,
        ICurrentCustomerInfoGetter currentService,
        ICustomerStore customerStore
        )
    {
        _store = orderStore;
        _avaliability = new(orderStore);
        _currentService = currentService;
        _customerStore = customerStore;
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

    public async Task<Result> CreateOrderFromCurrentUser(Order order)
    {
        var checkCreateOrderAvaliability = await _avaliability.CanCreateOrder(order);

        if(checkCreateOrderAvaliability.IsSucsesfull == false)
        {
            return Result.Failure(checkCreateOrderAvaliability.ErrorInfo);
        }

        var getTokenUserInfoResult = _currentService.Get();

        if(getTokenUserInfoResult.IsSucsesfull == false)
        {
            return Result.Failure(getTokenUserInfoResult.ErrorInfo);
        }

        var getUserByIdResult = await _customerStore.GetById(getTokenUserInfoResult.ResultValue.CustomerId);

        if(getUserByIdResult.IsSucsesfull == false)
        {
            throw new InvalidDataException("authed user not found");
        }

        order.Customer = getUserByIdResult.ResultValue;

        var createOrderResult = await _store.Create(order);

        if(createOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(createOrderResult.ErrorInfo);
        }
        return Result.Sucsesfull();

    }

    public async Task<Result> UpdateOwnedOrder(Order order)
    {
        var getUserAuthInfoResult = _currentService.Get();

        if(getUserAuthInfoResult.IsSucsesfull == false)
        {
            return Result.Failure(getUserAuthInfoResult.ErrorInfo);
        }

        var UserId = getUserAuthInfoResult.ResultValue.CustomerId;

        var getCustomerResult = await _customerStore.GetById(UserId);

        if(getCustomerResult.IsSucsesfull == false)
        {
            throw new InvalidCastException("authedUser dont exist");
        }

        if(getCustomerResult.ResultValue.Id != order.Customer.Id)
        {
            return Result.Failure(new Error("123", "its not owner"));
        }

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
        var getOrderResult = await _store.GetById(Id);

        if(getOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(new Error("123", "dont have order"));
        }

        var changeStateResult = await _store.ChangeState(Id, OrderStatus.Canceled);

        return changeStateResult;
    }
    public async Task<Result> CloseOwnerById(Guid Id)
    {
        var getUserAuthInfoResult = _currentService.Get();

        if(getUserAuthInfoResult.IsSucsesfull == false)
        {
            return Result.Failure(getUserAuthInfoResult.ErrorInfo);
        }

        var getUserResult = await _customerStore.GetById(getUserAuthInfoResult.ResultValue.CustomerId);

        if(getUserResult.IsSucsesfull == false)
        {
            throw new InvalidDataException("authed user dont have exist");
        }

        var getOrderResult = await _store.GetById(Id);

        if(getOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(new Error("123", "dont have order"));
        }

        if(getOrderResult.ResultValue.Customer.Id != getUserResult.ResultValue.Id)
        {
            return Result.Failure(new Error("123", "is not owner"));
        }

        var changeStateResult = await _store.ChangeState(Id, OrderStatus.Canceled);

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
