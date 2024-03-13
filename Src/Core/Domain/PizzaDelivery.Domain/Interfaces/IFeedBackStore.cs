using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Entitys.Order;

namespace PizzaDelivery.Domain.Interfaces;

public interface IFeedBackStore
{
    public List<Feedback> GetFeedbacksByDate(DateOnly date);
    public int GetMiddleScoreByDate(DateOnly date);
    public Order GetOrderByFeedbackId(Guid Id);
    public Feedback GetFeedbackForOrderByOrderId(Guid id);
    public void Update(Feedback feedback);
    public void DeliteById(Guid Id);
}
