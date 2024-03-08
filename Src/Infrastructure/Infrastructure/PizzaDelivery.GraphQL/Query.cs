using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.GraphQL.DTO;

namespace PizzaDelivery.GraphQL;

public class Query
{
    
    public DefaultResponse GetUserByToken(){}
    public DefaultResponse GetUserByRegistrateInfo(){}
    public DefaultResponse GetUsableAddress(){}

    public DefaultResponse GetOrdersCountByDay(){}
    public DefaultResponse GetCurrentOrdersCount(){}
    public DefaultResponse GetMostPopularAddreser(){}
    public DefaultResponse GetPersentOfSucsessfullDelivery(){}
    public DefaultResponse GetMiddleOrderPrice(){}
    public DefaultResponse GetLowestOrderPrice(){}
    public DefaultResponse GetHightestOrderPrice(){}

    public DefaultResponse GetLastNFeedback(){}
    public DefaultResponse GetMiddleScoreByDay(){}
    public DefaultResponse GetLowestScoreFeedbackByDay(){}

    public DefaultResponse GetMostPopularNIngridients(int n){}
    public DefaultResponse GetProductsWithIngridient(int ingridientId){}
    public DefaultResponse GetProductWithMostContainsIngridient(int ingridientId){}

    public DefaultResponse GetFirstNProduct(int n){}
    public DefaultResponse GetNMostLikedProduct(int n){}
    public DefaultResponse GetNMostDeliveredProduct(int n){}

}
