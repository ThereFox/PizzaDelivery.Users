using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Interfaces;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Service;

public class IngridientService
{
    private readonly IIngridientStore _ingridientStore;

    public IngridientService(
        IIngridientStore ingridientStore
    )
    {
        _ingridientStore = ingridientStore;
    }

    public async Task<Result<Ingridient>> GetById(Guid Id)
    {
        var Ingridient = await _ingridientStore.GetById(Id);
        return Ingridient;
    }

    public async Task<List<Ingridient>> GetN(int n)
    {
        var ingridients = await _ingridientStore.GetLastN(n);
        return ingridients;
    }

    public async Task<List<Ingridient>> GetNMostLiked(int n)
    {
        var ingridients = await _ingridientStore.GetNMostLiked(n);
        return ingridients;
    }

}
