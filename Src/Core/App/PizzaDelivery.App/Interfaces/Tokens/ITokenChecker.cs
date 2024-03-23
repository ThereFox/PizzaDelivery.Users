using PizzaDelivery.App.DTO;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Interfaces.Tokens;

public interface ITokenChecker
{
    public Result IsRefreshTokenAlive(string refreshToken);
    public Result<AuthTokenUserInfo> GetCustomerInfoFromToken(string authBearer);
}
