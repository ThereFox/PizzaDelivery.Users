using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.GraphQL.DTO;

public class DefaultResponse
{
    public static DefaultResponse Ok
    {
        get => new DefaultResponse("-1", "OK");
    }

    public string Code {get; private set;}
    public string Message {get; private set;}

    public DefaultResponse(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static DefaultResponse FromResult(Result result)
    {
        if(result.IsSucsesfull)
        {
            return Ok;
        }

        var errorInfo = result.ErrorInfo;

        return new DefaultResponse(
            errorInfo.Code,
            errorInfo.Message
            );
    }

}
