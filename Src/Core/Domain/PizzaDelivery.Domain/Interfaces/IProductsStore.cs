using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Ordering;
using PizzaDelivery.Domain.Filtrs;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.DAL.Interfaces;

public interface IProductsStore
{
    public Task<Result<Product>> GetById(Guid Id);
    public Task<List<Product>> GetFirstNByFiltr(ProductsFiltr filtr, int n);
    public Task<List<Product>> GetFirstNByFiltrWihtOrderingByIngridientContaining(ProductsFiltr filtr, int n);
    public Task<List<Product>> GetMostLikedNWithFiltr(ProductsFiltr filtr, int n);
    public Task<List<Product>> GetNMostDeliveredWithFiltr(ProductsFiltr filtr, int n);

    public Task<Result> AddProduct(Product product);
    public Task<Result> UpdateProduct(Product product);
    public Task<Result> DeleteProduct(int Id);

}
