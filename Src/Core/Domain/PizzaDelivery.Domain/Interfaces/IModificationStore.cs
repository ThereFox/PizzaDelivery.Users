using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Interfaces;

public interface IModificationStore
{
    public Task<Result<Modification>> GetById(Guid Id);
    public Task<Result<List<Modification>>> GetByIngridient(Guid ingridientId);

    public Task<Result> Create(Modification modification);
    public Task<Result> Update(Modification modification);
}
