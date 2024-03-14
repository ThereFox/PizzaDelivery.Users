using Microsoft.Extensions.DependencyInjection;
using Authorise.Logic;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.App.Interfaces.Tokens;

namespace ISTUTimeTable.Src.Infrastructure.Authorise.DIService;

public static class DI
{
    public static IServiceCollection AddCustomJWTService(this IServiceCollection service)
    {
        service.AddSingleton<ITokenGenerator, JWTTokenGenerator>();
        service.AddSingleton<ITokenChecker, JWTTokenReader>();

        return service;
    }
}
