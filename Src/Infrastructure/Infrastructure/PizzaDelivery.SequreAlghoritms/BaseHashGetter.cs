using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.Interfaces;

namespace PizzaDelivery.SequreAlghoritms;

public class BaseHashGetter : IHashGetter
{
    public string GetHash(string data)
    {
        return data;
    }
}
