using System.Runtime.InteropServices.JavaScript;
using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;


namespace Domain.Ordering;

public class Modification : Entity<Guid>
{
    public string Name { get; private set; }
    public decimal PriceChange { get; private set; }
    public int WeightChange { get; private set; }

    protected Modification(Guid id, string name, decimal priceChange, int weightChange)
    {
        Id = id;
        Name = name;
        PriceChange = priceChange;
        WeightChange = weightChange;
    }
    
    public static PizzaDelivery.Src.Core.Common.Result<Modification> Create(
        Guid id, 
        string name,
        decimal priceChange,
        int weightChange
        )
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Modification>(new Error("123", "name cannot be null or empty"));
        }

        return Result.Sucsesfull<Modification>(new Modification(id, name, priceChange, weightChange));
    }

    public Result ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            return Result.Failure(new Error("123", "name could be not null and not empty"));
        }

        Name = newName;
        return Result.Sucsesfull();
    }

    public Result ChangePrice(decimal newPrice)
    {
        PriceChange = newPrice;
        return Result.Sucsesfull();
    }

    public Result ChangeWeight(int newWeight)
    {
        WeightChange = newWeight;
        return Result.Sucsesfull();
    }
}