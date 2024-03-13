using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.Interfaces;

public interface IImageRepository
{
    public void AddImage(Image);
    public void RemoveImage();
    public List<object> GetImageForProduct(int productId);
}
