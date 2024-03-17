using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class FeedbackOutputeObject
{
    public int Score { get; private set; }
    public string Message { get; private set; }
    public OrderOutputeObject OrderInfo { get; private set; }
}
