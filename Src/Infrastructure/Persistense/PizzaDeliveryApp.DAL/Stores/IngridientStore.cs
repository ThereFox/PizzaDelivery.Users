using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class IngridientStore : IIngridientStore
{
    public Task<Result<Ingridient>> GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ingridient>> GetLastN(int n)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ingridient>> GetNMostLiked(int n)
    {
        throw new NotImplementedException();
    }
}
