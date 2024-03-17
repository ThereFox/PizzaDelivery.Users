using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;

namespace PizzaDelivery.DAL.Interfaces;

public interface IImageRepository
{
    public void AddImage(ProductImage image);
    public void RemoveImage();
    public List<object> GetImageForProduct(int productId);
}
