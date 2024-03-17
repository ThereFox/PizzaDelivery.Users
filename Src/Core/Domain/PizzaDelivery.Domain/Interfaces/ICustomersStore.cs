using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.DAL.Interfaces;

public interface ICustomerStore
{
    public Task<Result<Customer>> GetById(Guid id);
    public Task<Result<Customer>> GetByPhone(Phone phone);

    public Task<Result> Update(Customer customer);
}
