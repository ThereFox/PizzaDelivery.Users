using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;

namespace PizzaDelivery.App.Interfaces;

public interface ITokenGenerator
{
    public AuthBearer Generate(TokenContent content);
}
