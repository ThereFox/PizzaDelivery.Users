using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.App.Interfaces;

namespace PizzaDelivery.SequreAlghoritms;

public static class DI
{
    public static IServiceCollection AddSequreAlghoritms(this IServiceCollection provider)
    {
        provider
            .AddSingleton<IHashGetter, BaseHashGetter>();
        return provider;
    }
}