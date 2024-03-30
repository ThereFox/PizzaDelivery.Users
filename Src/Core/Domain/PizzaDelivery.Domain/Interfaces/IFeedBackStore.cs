using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ordering;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Interfaces;

public interface IFeedBackStore
{
    public Task<List<Feedback>> GetByDate(DateOnly date);
    public Task<Result<int>> GetMiddleScoreByDate(DateOnly date);
    public Task<Order> GetOrderByFeedbackId(Guid Id);
    public Task<Feedback> GetByOrderId(Guid id);
    public Task<List<Feedback>> GetLastN(int n);
    public Task<List<Feedback>> GetNLowestByDate(DateOnly date, int n); 

    public Task<List<Feedback>> GetByCreaterId(Guid Id);

    public Task<Result> AddToOrder(Guid orderId, Feedback feedback);
    public Task<Result> Update(Feedback feedback);
    public Task<Result> DeliteById(Guid Id);
}
