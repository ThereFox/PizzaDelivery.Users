using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class Customers
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public int DefaultAddresId { get; private set; }

    public List<AuthTokens> Tokens { get; private set; }
    public List<Orders> Orders { get; private set; }
    public Addreses DefaultAddres { get; private set; }
}
