using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class AddFeedbackRequest
{
    [GraphQLNonNullType]
    public Guid OrderId { get; private set; }
    
    [GraphQLNonNullType]
    public int Score { get; private set; }

    public string Message { get; private set; }
}
