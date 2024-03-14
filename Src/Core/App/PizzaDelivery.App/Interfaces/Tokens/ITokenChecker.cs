using PizzaDelivery.App.DTO;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Interfaces.Tokens;

public interface ITokenChecker
{
    public Task<Result> IsRefreshTokenAlive(string refreshToken);
    public Task<Result<AuthTokenUserInfo>> GetCustomerInfoFromToken(string authBearer);
}
