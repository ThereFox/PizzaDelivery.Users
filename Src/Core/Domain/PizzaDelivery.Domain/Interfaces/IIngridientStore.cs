using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Interfaces;

public interface IIngridientStore
{
    public Task<Result<Ingridient>> GetById(Guid Id);
}
