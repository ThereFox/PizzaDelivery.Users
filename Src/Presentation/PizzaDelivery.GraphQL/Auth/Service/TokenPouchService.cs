using Microsoft.AspNetCore.Http;
using PizzaDelivery.App.DTO;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.GraphQL.Auth.Service;

public class TokenPouchService
{
    private readonly IHttpContextAccessor _contextAcsessor;

    private const string AuthTokenHeaderName = "AuthToken";
    private const string RefreshTokenCookeyName = "RefreshToken";

    public TokenPouchService(IHttpContextAccessor contextAcsessor)
    {
        _contextAcsessor = contextAcsessor;
    }

    public void SendTokenToUser(AuthBearer bearer)
    {
        var getTokenResult = getTokenFromRequest();

        if(getTokenResult.IsSucsesfull == false)
        {
            //log
        }

        pushBearerToUser(bearer);

        //log
    }
    public Result<AuthBearer> GetTokensFromUser()
    {
        var getTokenResult = getTokenFromRequest();

        return getTokenResult;
    }
    private void pushBearerToUser(AuthBearer bearer)
    {
        var httpResponse = _contextAcsessor.HttpContext.Response;

        httpResponse.Headers[AuthTokenHeaderName] = bearer.AuthToken;
        httpResponse.Cookies.Append(RefreshTokenCookeyName, bearer.RefreshToken, new CookieOptions() { HttpOnly = true } );

    }
    private Result<AuthBearer> getTokenFromRequest()
    {
        var httpRequest = _contextAcsessor.HttpContext.Request;

        var authToken = httpRequest.Headers.FirstOrDefault(ex => ex.Key == AuthTokenHeaderName).Value;
        var refreshToken = httpRequest.Cookies.FirstOrDefault(ex => ex.Key == RefreshTokenCookeyName).Value;

        if( String.IsNullOrWhiteSpace(authToken) || String.IsNullOrWhiteSpace(refreshToken))
        {
            return Result.Failure<AuthBearer>(new Error("213", "DontHaveToken"));
        }

        return Result.Sucsesfull(new AuthBearer(authToken, refreshToken));
    }
}
