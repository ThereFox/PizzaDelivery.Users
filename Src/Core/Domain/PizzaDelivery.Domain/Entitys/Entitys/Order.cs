using CSharpFunctionalExtensions;
using Domain.Ordering.Aggregates;
using Domain.Ordering.ValueObjects;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering;

public class Order : Entity<Guid>
{
    public const decimal MinOrderPrice = 500;
    public const int MaxElementInOrder = 10;
    
    private readonly List<OrderElement> _elements;
    
    public Customer Owner { get; }
    public IReadOnlyCollection<OrderElement> Elements => _elements;
    
    public Address To { get; private set; }
    public string Comment { get; private set; }
    
    public DateTime CreateTime { get; }
    public DateTime LastUpdateTime { get; private set; }

    protected Order(Guid id, Customer creater, Address address, List<OrderElement> elements, string comment)
    {
        Id = id;
        Owner = creater;
        To = address;
        _elements = elements;
        Comment = comment;
    }
    
    public Result AddElemet(OrderElement element)
    {
        if (_elements.Sum(ex => ex.Count) + element.Count > MaxElementInOrder)
        {
            return Result.Failure(new Error("123", "too many elements in order"));
        }

        _elements.Add(element);
        
        LastUpdateTime = DateTime.Now;
        return Result.Sucsesfull();
    }
    
    public Result RemoveElement(Guid id)
    {
        if (_elements.Any(ex => ex.Id == id) == false)
        {
            return Result.Failure(new Error("123", "dont have element in order"));
        }

        _elements.RemoveAll(ex => ex.Id == id);
        
        LastUpdateTime = DateTime.Now;
        return Result.Sucsesfull();
    }

    public Result ChangeComment(string comment)
    {
        if (string.IsNullOrWhiteSpace(comment))
        {
            Comment = "";
            return Result.Sucsesfull();
        }

        Comment = comment;
        LastUpdateTime = DateTime.Now;
        return Result.Sucsesfull();

    }

    public Result ChangeAddress(Address address)
    {
        if (address == To)
        {
            return Result.Failure(new Error("123", "adresses equaeled"));
        }

        To = address;
        LastUpdateTime = DateTime.Now;
        return Result.Sucsesfull();
    }

    public static PizzaDelivery.Src.Core.Common.Result<Order> Create(Guid id, Customer creater, Address address, List<OrderElement> elements, string comment)
    {
        if (elements.Any() == false)
        {
            return Result.Failure<Order>(new Error("123", "dont have elements in order"));
        }

        if (elements.Sum(ex => ex.Count) > MaxElementInOrder)
        {
            return Result.Failure<Order>(new Error("123", "too many elements in order"));
        }

        if (elements.Sum(ex => ex.Price) < MinOrderPrice)
        {
            return Result.Failure<Order>(new Error("123", "order price low min order price"));
        }

        return Result.Sucsesfull<Order>(new Order(id, creater, address, elements, comment));
    }
}