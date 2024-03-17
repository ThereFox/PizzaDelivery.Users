using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.GraphQL.Auth.Service;

namespace PizzaDelivery.GraphQL;

public static class DI
{
    public static IServiceCollection AddGraphQLApi(this IServiceCollection provider)
    {
        provider
            .AddGraphQL()
            .AddAuthorizationCore()
            .AddAuthorizationHandler<AuthHandler>()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();
        return provider;
    }
}
