using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ordering;
using Domain.Ordering.ValueObjects;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.DAL.Interfaces;

public interface ICustomerStore
{
    public Task<Result<Customer>> GetById(Guid id);
    public Task<Result<Customer>> GetByPhone(Phone phone);

    public Task<Result<Address>> GetMostUseableAddresForUser(Guid userId);

    public Task<Result> Update(Customer customer);
}
