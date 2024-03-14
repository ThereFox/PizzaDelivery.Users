using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.App.DTO;

public class CustomerRegistrateInfo
{
    public Phone Phone {get; set;}
    public string Name { get; set; }
    public string Password { get; set; }
}
