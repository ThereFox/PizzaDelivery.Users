using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.GraphQL.Auth.Service;

namespace PizzaDelivery.GraphQL;

public static class DI
{
    public static IServiceCollection AddGraphQLApi(this IServiceCollection provider)
    {        
        provider.AddAuthorization();


        provider
            .AddGraphQLServer()
            .AddAuthorizationCore()
            .AddAuthorizationHandler<AuthHandler>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .ModifyRequestOptions(ex => ex.IncludeExceptionDetails = true);

        provider.AddTransient<ICurrentCustomerInfoGetter, WebCurrentCustomerInfoGetter>();

        provider.AddSingleton<TokenPouchService>();

        return provider;
    }
}
