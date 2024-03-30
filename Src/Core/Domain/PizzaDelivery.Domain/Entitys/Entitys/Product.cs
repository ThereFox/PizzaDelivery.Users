using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering;

public class Product : Entity<Guid>
{
    private readonly List<Ingridient> _ingridients;
    private readonly List<Modification> _modifications;

    public string Name { get; private set; }

    public IReadOnlyCollection<Ingridient> Ingridients => _ingridients;

    public IReadOnlyCollection<Modification> AvaliableModifications => _modifications;

    public decimal Price { get; private set; }
    public int WeightInGrams { get; private set; }

    protected Product(Guid id, string name, List<Ingridient> ingridients, List<Modification> modifications, decimal price, int weight)
    {
        Id = id;
        Name = name;
        _ingridients = ingridients;
        _modifications = modifications;
        Price = price;
        WeightInGrams = weight;
    }
    
    public static PizzaDelivery.Src.Core.Common.Result<Product> Create(Guid id, string name, List<Ingridient> ingridients, List<Modification> modifications, decimal price, int weight)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Product>(new Error("123", "name cannot be null or empty"));
        }
        if (ingridients.Count == 0)
        {
            return Result.Failure<Product>(new Error("123", "product must contain ingridients"));
        }
        if (price < 0)
        {
            return Result.Failure<Product>(new Error("123", "price must be"));
        }
        if (weight <= 0)
        {
            return Result.Failure<Product>(new Error("123", "weight must be"));
        }
        return Result.Sucsesfull<Product>(new Product(id, name, ingridients, modifications, price, weight));
    }

    public Result ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            return Result.Failure(new Error("123", "name must be not null or empty"));
        }

        Name = newName;
        
        return Result.Sucsesfull();
    }

    public Result ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
        {
            return Result.Failure(new Error("123", "price must be more that zero"));
        }

        Price = newPrice;
        return Result.Sucsesfull();
    }

    public Result ChangeWeight(int newWeight)
    {
        if (newWeight <= 0)
        {
            return Result.Failure(new Error("123", "weight must be"));
        }

        WeightInGrams = newWeight;
        return Result.Sucsesfull();
    }

    public Result AddIngridient(Ingridient ingridient)
    {
        _ingridients.Add(ingridient);
        return Result.Sucsesfull();
    }

    public Result RemoveIngridient(Ingridient ingridient)
    {
        _ingridients.RemoveAll(ex => ex.Id == ingridient.Id);
        return Result.Sucsesfull();
    }

    public Result AddAvaliableModification(Modification modification)
    {
        _modifications.Add(modification);
        return Result.Sucsesfull();
    }

    public Result RemoveAvaliableModification(Modification modification)
    {
        _modifications.RemoveAll(ex => ex.Id == modification.Id);
        return Result.Sucsesfull();
    }


}