using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.GraphQL.DTO;

namespace PizzaDelivery.GraphQL;

public class Mutation
{
    
    public DefaultResponse Registrate(){}
    public DefaultResponse RefreshToken(){}
    public DefaultResponse Authorise(){}

    public DefaultResponse CreateOrder(){}
    public DefaultResponse CloseOrder(){}
    public DefaultResponse UpdateOrder(){}

    public DefaultResponse AddFeedback(){}

    public DefaultResponse AddProduct(){}
    public DefaultResponse RemoveProduct(){}

}
