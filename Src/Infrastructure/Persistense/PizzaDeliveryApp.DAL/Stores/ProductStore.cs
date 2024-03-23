using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.DAL.Interfaces;
using PizzaDelivery.Domain.Entitys;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDeliveryApp.DAL.Stores;

public class ProductStore : IProductsStore
{
    public Task<Result> AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteProduct(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Product>> GetById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetFirstNByFiltr(ProductsFiltr filtr, int n)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetFirstNByFiltrWihtOrderingByIngridientContaining(ProductsFiltr filtr, int n)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMostLikedNWithFiltr(ProductsFiltr filtr, int n)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetNMostDeliveredWithFiltr(ProductsFiltr filtr, int n)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
