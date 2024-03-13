using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.DAL.Interfaces;

public interface IProductsStore
{
    public List<Product> GetFirstN(int n);
    public List<Product> GetMostLikedN(int n);
    public List<Product> GetMostDelivered(int n);

    public void AddProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(int Id);

}
