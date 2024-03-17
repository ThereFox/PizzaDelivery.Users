using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.GraphQL.DTO;

public class DefaultResponse
{
    public int Code {get; private set;}
    public string Message {get; private set;}

    public DefaultResponse(int code, string message)
    {
        Code = code;
        Message = message;
    }
}
