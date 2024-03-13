using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Entitys;

public class Phone
{
    private string _number = string.Empty;
    public string Number
    {
        get => _number;
        set
        {
            if(Regex.IsMatch(value, "+7[0-9]{10}") == false)
            {
                throw new InvalidDataException("PhoneNumber invalid");
            }
            _number = value;
        }
    }
    public Phone(string number)
    {
        Number = number;
    }

}
