using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class FeedbackStore : IFeedBackStore
{
    public Task<Result> AddToOrder(Guid orderId, Feedback feedback)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeliteById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Feedback>> GetByCreaterId(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Feedback>> GetByDate(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task<Feedback> GetByOrderId(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Feedback>> GetLastN(int n)
    {
        throw new NotImplementedException();
    }

    public Task<Result<int>> GetMiddleScoreByDate(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task<List<Feedback>> GetNLowestByDate(DateOnly date, int n)
    {
        throw new NotImplementedException();
    }

    public Task<Order> GetOrderByFeedbackId(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Feedback feedback)
    {
        throw new NotImplementedException();
    }
}
