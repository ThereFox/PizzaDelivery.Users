using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Interfaces;

public interface IAuthDataStore
{
    public Task<Result> CreateCustomer(CustomerRegistrateInfo registrateInfo);
    public Task<Result> HaveCustomer(CustomerAuthoriseInfo authoriseInfo);
}
