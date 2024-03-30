using CSharpFunctionalExtensions;
using Domain.Ordering.ValueObjects;
using PizzaDelivery.Src.Core.Common;

using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering;

public class Customer : Entity<Guid>
{
    private List<Order> _orders;
    public string Name { get; private set; }
    public Phone Phone { get; private set; }
    public IReadOnlyCollection<Order> Orders => _orders; 
    protected Customer(Guid id, string name, Phone phone, List<Order> orders)
    {
        Id = id;
        Name = name;
        Phone = phone;
        _orders = orders;
    }
    public static PizzaDelivery.Src.Core.Common.Result Create(Guid id, string name, Phone phone, List<Order> orders)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Customer>(new Error("123","name cannot be null"));
        }

        if (orders.Any(ex => ex.Owner.Id != id))
        {
            return Result.Failure<Customer>(new Error("123","not all orders owner by current user"));
        }
        
        return Result.Sucsesfull<Customer>(new (id, name, phone, orders));
    }
    public Result ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Customer>(new Error("123", "name cannot be null or whitespaces"));
        }

        Name = name;
        
        return Result.Sucsesfull();
    }
    public Result ChangePhone(Phone phone)
    {
        if (Phone == phone)
        {
            return Result.Failure(new Error("123", "nothing to change"));
        }


        Phone = phone;
        
        return Result.Sucsesfull();
    }
    
}