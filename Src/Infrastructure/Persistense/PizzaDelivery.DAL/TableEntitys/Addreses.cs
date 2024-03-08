using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class Addreses
{
    public int Id { get; private set; }
    public string City { get; private set; }
    public string Street { get; private set; }
    public string House { get; private set; }
    public string Room { get; private set; }

    public List<Orders> Orders { get; private set; }
    public List<Customers> UsersWithThisAddresAsDefault { get; private set; }
}
