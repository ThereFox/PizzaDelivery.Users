using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering.ValueObjects;

public class Address : ValueObject
{
    public string City { get; }
    public string Street { get; }
    public string House { get; }
    public string Room { get; }

    protected Address(string city, string street, string house, string room)
    {
        City = city;
        Street = street;
        House = house;
        Room = room;
    }
    
    public static PizzaDelivery.Src.Core.Common.Result<Address> Create(string city, string street, string house, string? room)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return Result.Failure<Address>(new Error("123", "city must be not null or empty"));
        }
        if (string.IsNullOrWhiteSpace(street))
        {
            return Result.Failure<Address>(new Error("123", "street must be not null or empty"));
        }
        if (string.IsNullOrWhiteSpace(house))
        {
            return Result.Failure<Address>(new Error("123", "house must be not null or empty"));
        }

        return Result.Sucsesfull<Address>(new(city, street, house, room));
    }
    
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return City;
        yield return Street;
        yield return House;
        yield return Room;
    }
}