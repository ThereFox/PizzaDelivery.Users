using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Feedback
{
    public Guid Id { get; init; }
    public int Score { get; set;}
    public string Message { get; set; }
}
