using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO.OutputeObjects;

public class FeedbackOutputeObject
{
    public int Score { get; init; }
    public string Message { get; init; }
    public OrderOutputeObject OrderInfo { get; private set; }
}
