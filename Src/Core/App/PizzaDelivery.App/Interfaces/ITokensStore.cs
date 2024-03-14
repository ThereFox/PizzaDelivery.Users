using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Core.App.Interfaces;

public interface ITokensStore
{
    public Result SaveToken(string RefreshToken, Guid OwnerId);
    public Task<bool> HaveToken(string RefreshToken);
    public Task<Result<Customer>> GetOwner(string RefreshToken);
}
