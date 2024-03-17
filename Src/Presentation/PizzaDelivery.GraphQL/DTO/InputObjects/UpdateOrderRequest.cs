using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

namespace PizzaDelivery.GraphQL.DTO.InputObjects;

public class UpdateOrderRequest
{
    public List<ProductInputObject> Products { get; set;}
    public AddresInputObject Addres { get; private set; }
    
    public string Comment { get; private set; }

}
