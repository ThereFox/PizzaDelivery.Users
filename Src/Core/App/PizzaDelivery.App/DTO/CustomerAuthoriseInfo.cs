using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.App.DTO;

public class CustomerAuthoriseInfo
{
    public Phone Phone { get; set; }
    public string PasswordHash { get; set; }

    public CustomerAuthoriseInfo(Phone phone, string passwordHash)
    {
        Phone = phone;
        PasswordHash = passwordHash;
    }
}
