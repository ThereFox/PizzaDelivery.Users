using System.Threading.Tasks;
using HotChocolate.Types;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.App.Service;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.GraphQL.Auth.Attributes;
using PizzaDelivery.GraphQL.DTO;
using PizzaDelivery.GraphQL.DTO.OutputeObjects;
using Src.Core.App.Service;

using Result = PizzaDelivery.Src.Core.Common.Result;

namespace PizzaDelivery.GraphQL;

public class Query
{
    private readonly CustomerService _customers;
    private readonly FeedbackService _feedbacks;
    private readonly ProductService _products;
    private readonly ModificationService _modification;
    private readonly OrderService _orders;
    private readonly IngridientService _ingridients;

    public Query(
        CustomerService customerService,
        ProductService productService,
        ModificationService modificationService,
        OrderService orderService,
        FeedbackService feedbackService,
        IngridientService ingridients
        )
    {
        _customers = customerService;
        _products = productService;
        _modification = modificationService;
        _orders = orderService;
        _feedbacks = feedbackService;
        _ingridients = ingridients;
    }

    [CustomerAuthorise]
    public async Task<CustomerOutputeObject> GetCurrentUserInfo()
    {
        var getCurrentCustomerResult = await _customers.GetInfoByCurrentUser();

        if(getCurrentCustomerResult.IsSucsesfull == false)
        {
            throw new Exception("user dont auth");
        }

        var getCurrentCustomer = getCurrentCustomerResult.ResultValue;

        return new CustomerOutputeObject()
        {
            Id = getCurrentCustomer.Id,
            Name = getCurrentCustomer.Name,
            PhoneNumber = getCurrentCustomer.Phone.Number
        };
    }

    [AdminAuthorise]
    [Error<Exception>]
    public async Task<CustomerOutputeObject> GetUserInfo(Guid id)
    {
        var getCustomerByIdResult = await _customers.GetById(id);

        if(getCustomerByIdResult.IsSucsesfull == false)
        {
            throw new Exception(getCustomerByIdResult.ErrorInfo.Message.ToString());
        }

        var customerInfo = getCustomerByIdResult.ResultValue;

        return new CustomerOutputeObject()
        {
            Id = customerInfo.Id,
            Name = customerInfo.Name,
            PhoneNumber = customerInfo.Phone.Number
        };
    }
    
    [CustomerAuthorise]
    public async Task<Address> GetOwnMostUsableAddress()
    {
        var getMostUsableAddresResult = await _customers.GetMostUsableAddresForCurrentUser();

        return getMostUsableAddresResult.IsSucsesfull ? getMostUsableAddresResult.ResultValue : null;
    }

    [AnyAuthorise]
    public async Task<int> GetOrdersCountByDate(DateOnly date)
    {
        var orderCountByDateResult = await _orders.GetOrdersCountByDate(date);

        return orderCountByDateResult;
    }
    
    [AnyAuthorise]
    public async Task<int> GetCurrentOrdersCount()
    {
        var currentOrdersCount = await _orders.GetCountOfCurrentActiveOrders();
        return currentOrdersCount;
    }
        
    [AnyAuthorise]
    public async Task<float> GetPersentOfSucsessfullDeliveryOnCurrentDay()
    {
        var GetPersentOfSucsessfullDeliveryResult = await _orders.GetPersentOfSucsessfullByDate(DateOnly.FromDateTime(DateTime.Now));

        return GetPersentOfSucsessfullDeliveryResult.IsSucsesfull ? GetPersentOfSucsessfullDeliveryResult.ResultValue : 1f;
    }
    
    [AdminAuthorise]
    public async Task<decimal> GetMiddleOrderPriceByCurrentDate()
    {
        var middleOrderPrice = await _orders.GetMiddlePriceByDate(DateOnly.FromDateTime(DateTime.Now));

        return middleOrderPrice.IsSucsesfull ? middleOrderPrice.ResultValue : 0;
    }
    
    [AdminAuthorise]
    public async Task<decimal> GetLowestOrderPriceByCurrentDate()
    {
        var getLowestOrderPriceResult = await _orders.GetLowestPriceByDate(DateOnly.FromDateTime(DateTime.Now));

        return getLowestOrderPriceResult.IsSucsesfull ? getLowestOrderPriceResult.ResultValue : -1;
    }
    
    [AdminAuthorise]
    public async Task<decimal> GetHightestOrderPriceByCurrentDate()
    {
        var getHigestOrderPriceResult = await _orders.GetHightestPriceByDate(DateOnly.FromDateTime(DateTime.Now));

        return getHigestOrderPriceResult.IsSucsesfull ? getHigestOrderPriceResult.ResultValue : -1;
    }

    [AnyAuthorise]
    public async Task<List<FeedbackOutputeObject>> GetLastNFeedback(int n)
    {
        var feedbacks = await _feedbacks.GetLastNFeedback(n);

        return feedbacks.ConvertAll(ex => new FeedbackOutputeObject() { Message = ex.Message, Score = ex.Score });
    }
    
    [AnyAuthorise]
    public async Task<int> GetMiddleScoreByCurrentDay()
    {
        var GetMiddleScoreByDayResult = await _feedbacks.GetMiddleScoreByDay(DateOnly.FromDateTime(DateTime.Now));
        return GetMiddleScoreByDayResult.IsSucsesfull ? GetMiddleScoreByDayResult.ResultValue : -1;
    }
    
    [AdminAuthorise]
    public async Task<FeedbackOutputeObject> GetLowestScoreFeedbackByDay()
    {
        var lowestScore = await _feedbacks.GetLowestScoreFeedbackByDay(DateOnly.FromDateTime(DateTime.Now));

        var outputeObject = new FeedbackOutputeObject() { Message = lowestScore.ResultValue.Message, Score = lowestScore.ResultValue.Score };

        return lowestScore.IsSucsesfull ? outputeObject : null;
    }

    [AnyAuthorise]
    public async Task<List<Ingridient>> GetMostPopularNIngridients(int n)
    {
        var mostPopularIngridients = await _ingridients.GetNMostLiked(n);

        return mostPopularIngridients;
    }

    [AnyAuthorise]
    public async Task<List<Ingridient>> GetNIngridients(int n)
    {
        var mostPopularIngridients = await _ingridients.GetN(n);

        return mostPopularIngridients;
    }
    
    [AnyAuthorise]
    [Error<Exception>]
    public async Task<List<Product>> GetNProductsWithIngridient(Guid ingridientId, int n)
    {
        var getProductWithIngridientResult = await _products.GetNWithInfridient(ingridientId, n);

        if(getProductWithIngridientResult.IsSucsesfull == false)
        {
            throw new Exception(getProductWithIngridientResult.ErrorInfo.Message);
        }

        return getProductWithIngridientResult.ResultValue;
    }
    
    [AnyAuthorise]
    [Error<Exception>]
    public async Task<List<Product>> GetNProductWithMostContainsIngridient(Guid ingridientId, int n)
    {
        var getProductsWithMostContainingIngridientResult = await _products.GetNWithMostContainsInfridient(ingridientId, n);

        if(getProductsWithMostContainingIngridientResult.IsSucsesfull == false)
        {
            throw new Exception(getProductsWithMostContainingIngridientResult.ErrorInfo.Message);
        }

        return getProductsWithMostContainingIngridientResult.ResultValue;
    }

    [CustomerAuthorise]
    public async Task<List<Product>> GetFirstNProduct(int n)
    {
        var products = await _products.GetFirstNProduct(n);

        return products;
    }

    [AnyAuthorise]
    public async Task<List<Product>> GetNMostLikedProduct(int n)
    {
        var mostLiked = await _products.GetNMostLikedProduct(n);

        return mostLiked;
    }

    [AnyAuthorise]
    public async Task<List<Product>> GetNMostOrderedProduct(int n)
    {
        var mostOrdered = await _products.GetNMostDeliveredProduct(n);

        return mostOrdered;
    }

}
