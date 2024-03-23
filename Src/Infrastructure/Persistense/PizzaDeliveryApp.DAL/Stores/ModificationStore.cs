using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class ModificationStore : IModificationStore
{
    public Task<Result> Create(Modification modification)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Modification>> GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<Modification>>> GetByIngridient(Guid ingridientId)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Update(Modification modification)
    {
        throw new NotImplementedException();
    }
}
