using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class OrderFeedbacks
{
    public int Id { get; private set; }
    public int Score { get; private set; }
    public string Message { get; private set; }
    public int OrderId { get; private set; }

    public Orders Order { get; private set; }
}
