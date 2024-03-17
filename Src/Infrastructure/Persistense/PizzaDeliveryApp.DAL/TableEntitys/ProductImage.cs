using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.DAL.TableEntitys;

public class ProductImage
{
    public int Id { get; private set; }
    public byte[] Image { get; private set; }
    public int ProductId { get; private set; }

    public Products Product { get; private set; }
}
