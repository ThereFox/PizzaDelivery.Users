using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys.Order;

namespace PizzaDelivery.Domain.Filtrs;

public record OrdersFiltr
(
    IEnumerable<Guid> UsersGuids,
    IEnumerable<DateOnly> Dates,
    IEnumerable<OrderStatus> OrderStatuses
);
