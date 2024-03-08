using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class AuthTokens
{
    public int Id { get; private set; }
    public int OwnerId { get; private set; }
    public DateTime EndOfLife { get; private set; }
    public string Token { get; private set; }

    public Customers Customer { get; private set; }
}
