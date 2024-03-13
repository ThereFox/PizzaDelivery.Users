using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Common;

namespace PizzaDelivery.DAL.DTO;

public class AuthoriseInfo
{
    public PhoneNumber PhoneNumber { get; private set; }
    public string Password { get; private set; }
}
