using PizzaDelivery.App.DTO;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Interfaces.Tokens;

public interface ITokenChecker
{
    public Task<Result> IsValidToken(string token);
    public Task<Result<AuthTokenUserInfo>> GetCustomerInfo(string authBearer);

}
