using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.App.Interfaces;

public interface IHashGetter
{
    public string GetHash(string data);
}
