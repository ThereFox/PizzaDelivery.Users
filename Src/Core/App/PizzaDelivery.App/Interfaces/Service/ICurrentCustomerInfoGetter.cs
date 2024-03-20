using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.App.Interfaces.Service;

public interface ICurrentCustomerInfoGetter
{
    public AuthTokenUserInfo Get();
}
