using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.App.DTO;
using PizzaDelivery.DAL.Interfaces;

namespace PizzaDeliveryApp.DAL.Stores;

public class ImageStore : IImageRepository
{
    public void AddImage(ProductImage image)
    {
        throw new NotImplementedException();
    }

    public List<object> GetImageForProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public void RemoveImage()
    {
        throw new NotImplementedException();
    }
}
