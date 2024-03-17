using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Common;

namespace PizzaDelivery.DAL.DTO;

public class RegistrateInfoDTO
{
    public string Name { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Password { get; private set; }

    public RegistrateInfoDTO(string name, string PhoneNumber, string password)
    {
        
    }
}
