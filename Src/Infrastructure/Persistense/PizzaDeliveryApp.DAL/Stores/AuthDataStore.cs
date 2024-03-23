using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;
using PizzaDelivery.App.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class AuthDataStore : IAuthDataStore
{
    public Task<Result> CreateCustomer(CustomerRegistrateInfo registrateInfo)
    {
        throw new NotImplementedException();
    }

    public Task<Result> HaveCustomer(CustomerAuthoriseInfo authoriseInfo)
    {
        throw new NotImplementedException();
    }
}
