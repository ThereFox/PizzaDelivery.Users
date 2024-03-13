using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys.Customer;

namespace PizzaDelivery.Core.App.Interfaces;

public interface ITokensStore
{
    public void SaveToken(string RefreshToken);
    public bool HaveToken(string RefreshToken);
    public Customer GetOwner(string RefreshToken);
    public void RefreshTokens(string RefreshToken);
}
