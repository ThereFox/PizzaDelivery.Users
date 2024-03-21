using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Service;

public class FeedbackService
{
    private readonly IFeedBackStore _feedBackStore;
    private readonly ICurrentCustomerInfoGetter _current;
    private readonly ICustomerStore _customerStore;
    private readonly IOrderStore _orderStore;

    public FeedbackService(
        IFeedBackStore feedBackStore,
        ICurrentCustomerInfoGetter _currentService,
        ICustomerStore customerStore,
        IOrderStore orderStore)
    {
        _feedBackStore = feedBackStore;
        _current = _currentService;
        _customerStore = customerStore;
        _orderStore = orderStore;
    }

    public async Task<List<Feedback>> GetForCurrentUser()
    {
        var userId = _current.Get().CustomerId;

        var getCustomerResult = await _customerStore.GetById(userId); 

        if(getCustomerResult.IsSucsesfull == false)
        {
            throw new InvalidCastException("authed data uncurrect");
        }

        var feedbacksFromUser = await _feedBackStore.GetByCreaterId(userId);

        return feedbacksFromUser;
    }

    public async Task<List<Feedback>> GetLastNFeedback(int n)
    {
        var getLastNFeedback = await _feedBackStore.GetLastN(n);

        return getLastNFeedback;
    }
    public async Task<Result<int>> GetMiddleScoreByDay(DateOnly date)
    {
        var middleScore = await _feedBackStore.GetMiddleScoreByDate(date);

        return middleScore;
    }
    public async Task<Result<Feedback>> GetLowestScoreFeedbackByDay(DateOnly date)
    {
        var getLowestOrderList = await _feedBackStore.GetNLowestByDate(date, 1);

        if(getLowestOrderList.Count != 0)
        {
            return Result.Failure<Feedback>(new Error("123", "dont have orders by date"));
        }

        return Result.Sucsesfull<Feedback>(getLowestOrderList[0]);
    }

    public async Task<Result> AddToOrder(Guid orderId, Feedback feedback)
    {
        var getOrderResult = await _orderStore.GetById(orderId);

        if(getOrderResult.IsSucsesfull == false)
        {
            return Result.Failure(new Error("123", "dont have order"));
        }
        
        var currentUserInfo = _current.Get();
        var currentUserResult = await _customerStore.GetById(currentUserInfo.CustomerId);

        if(currentUserResult.IsSucsesfull == false)
        {
            throw new InvalidDataException("authed user dont have exist");
        }

        if(getOrderResult.ResultValue.Id != currentUserResult.ResultValue.Id)
        {
            return Result.Failure(new Error("123", "is not owner"));
        }

        var addFeedbackResult = await _feedBackStore.AddToOrder(orderId, feedback);

        return addFeedbackResult;

    }

}
