using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.App.Service;
using PizzaDelivery.Core.App.Service;
using Src.Core.App.Service;

namespace PizzaDelivery.App;

public static class DI
{
    public static IServiceCollection AddAppServices(this IServiceCollection provider)
    {
        provider
            .AddSingleton<TokenAuthService>()
            .AddSingleton<CustomerService>()
            .AddSingleton<FeedbackService>()
            .AddSingleton<IngridientService>()
            .AddSingleton<ModificationService>()
            .AddSingleton<OrderService>()
            .AddSingleton<ProductService>();
        return provider;
    }
}