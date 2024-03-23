using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.Core.App.Interfaces;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Interfaces;
using PizzaDeliveryApp.DAL.Stores;

namespace PizzaDeliveryApp.DAL;

public static class DI
{
    public static IServiceCollection AddEFDAL(this IServiceCollection provider)
    {
        provider
            .AddSingleton<IAuthDataStore, AuthDataStore>()
            .AddSingleton<ICustomerStore, CustomerStore>()
            .AddSingleton<IFeedBackStore, FeedbackStore>()
            .AddSingleton<IImageRepository, ImageStore>()
            .AddSingleton<IIngridientStore, IngridientStore>()
            .AddSingleton<IModificationStore, ModificationStore>()
            .AddSingleton<IOrderStore, OrderStore>()
            .AddSingleton<IProductsStore, ProductStore>()
            .AddSingleton<ITokensStore, TokensStore>();
        return provider;
    }
}