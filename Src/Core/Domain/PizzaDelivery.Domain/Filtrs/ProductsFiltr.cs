using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Domain.Filtrs;

public record ProductsFiltr
(
    IEnumerable<Guid> Ingridients
);
