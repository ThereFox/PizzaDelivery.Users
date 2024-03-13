using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.DAL.Interfaces;

public interface ICustomerStore
{
    public Customer GetById(Guid id);
    public Customer GetByPhone(Phone phone);

    public void Create(Customer customer, string Password);
    public void Update(Customer customer);
}
