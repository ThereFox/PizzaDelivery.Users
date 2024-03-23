using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class CustomerStore : ICustomerStore
{
    public Task<Result<Customer>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Customer>> GetByPhone(Phone phone)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Address>> GetMostUseableAddresForUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}
