using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.App.DTO;

public class AuthBearer
{
    public string AuthToken {get;set;}
    public string RefreshToken {get;set;}
    public AuthBearer(string auth, string refresh)
    {
        AuthToken = auth;
        RefreshToken = refresh;
    }
}

