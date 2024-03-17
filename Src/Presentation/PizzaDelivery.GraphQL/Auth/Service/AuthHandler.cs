using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Authorization;
using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Http;
using PizzaDelivery.App.DTO;
using PizzaDelivery.Core.App.Service;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.GraphQL.Auth.Service;

public class AuthHandler : IAuthorizationHandler
{
    private readonly TokenAuthService _tokenAuthService;
    private readonly TokenPouchService _tokenPouch;

    public AuthHandler(TokenAuthService tokenAuthService, TokenPouchService tokenPouch)
    {
        _tokenAuthService = tokenAuthService;
        _tokenPouch = tokenPouch;
    }

    public async ValueTask<AuthorizeResult> AuthorizeAsync(IMiddlewareContext context, AuthorizeDirective directive, CancellationToken cancellationToken = default)
    {
        var getBearerResult = _tokenPouch.GetTokensFromUser();

        if(getBearerResult.IsSucsesfull == false)
        {
            return AuthorizeResult.NotAllowed;
        }

        var authoriseResult = await _tokenAuthService.AuthoriseByAuthToken(getBearerResult.ResultValue.AuthToken);

        if(authoriseResult.IsSucsesfull == false)
        {
           var refreshTokenResult = await _tokenAuthService.RefreshTokens(getBearerResult.ResultValue.RefreshToken);

            if(refreshTokenResult.IsSucsesfull == false)
            {
                return AuthorizeResult.NotAllowed;
            }

            _tokenPouch.SendTokenToUser(refreshTokenResult.ResultValue);
            
            return AuthorizeResult.Allowed;
        }
        return AuthorizeResult.Allowed;
    }

    public async ValueTask<AuthorizeResult> AuthorizeAsync(AuthorizationContext context, IReadOnlyList<AuthorizeDirective> directives, CancellationToken cancellationToken = default)
    {
        var getBearerResult = _tokenPouch.GetTokensFromUser();

        if(getBearerResult.IsSucsesfull == false)
        {
            return AuthorizeResult.NotAllowed;
        }

        var authoriseResult = await _tokenAuthService.AuthoriseByAuthToken(getBearerResult.ResultValue.AuthToken);

        if(authoriseResult.IsSucsesfull == false)
        {
           var refreshTokenResult = await _tokenAuthService.RefreshTokens(getBearerResult.ResultValue.RefreshToken);

            if(refreshTokenResult.IsSucsesfull == false)
            {
                return AuthorizeResult.NotAllowed;
            }

            _tokenPouch.SendTokenToUser(refreshTokenResult.ResultValue);
            
            return AuthorizeResult.Allowed;
        }
        return AuthorizeResult.Allowed;
    }

}
