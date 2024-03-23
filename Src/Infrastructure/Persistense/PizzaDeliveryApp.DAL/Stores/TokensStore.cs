using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Core.App.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class TokensStore : ITokensStore
{
    public Task<Result<Customer>> GetOwner(string RefreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HaveToken(string RefreshToken)
    {
        throw new NotImplementedException();
    }

    public Result SaveToken(string RefreshToken, Guid OwnerId)
    {
        throw new NotImplementedException();
    }
}
