using PizzaDelivery.App.DTO;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.App.Interfaces.Tokens;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.GraphQL.Auth.Service;

public class WebCurrentCustomerInfoGetter : ICurrentCustomerInfoGetter
{
    private readonly TokenPouchService _tokenPouchService;
    private readonly ITokenChecker _tokenChecker;

    public WebCurrentCustomerInfoGetter(
        TokenPouchService pouchService,
        ITokenChecker checker
        )
    {
        _tokenPouchService = pouchService;
        _tokenChecker = checker;
    }

    public Result<AuthTokenUserInfo> Get()
    {
        var getTokensResult = _tokenPouchService.GetTokensFromUser();
        
        if(getTokensResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthTokenUserInfo>(getTokensResult.ErrorInfo);
        }

        var getCustomerResult = _tokenChecker.GetCustomerInfoFromToken(getTokensResult.ResultValue.AuthToken);

        if(getCustomerResult.IsSucsesfull == false)
        {
            return Result.Failure<AuthTokenUserInfo>(getCustomerResult.ErrorInfo);
        }
        return Result.Sucsesfull(getCustomerResult.ResultValue);
    }
}
