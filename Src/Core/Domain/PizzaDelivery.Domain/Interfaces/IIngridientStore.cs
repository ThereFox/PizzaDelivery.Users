using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ordering;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.Domain.Interfaces;

public interface IIngridientStore
{
    public Task<Result<Ingridient>> GetById(Guid Id);
    public Task<List<Ingridient>> GetNMostLiked(int n);
    public Task<List<Ingridient>> GetLastN(int n);
}
