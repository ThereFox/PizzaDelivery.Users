using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering;

public class Ingridient : Entity<Guid>
{
    public string Name { get; private set; }

    protected Ingridient(string name)
    {
        Name = name;
    }
    
    public static Result Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Ingridient>(new Error("123", "name cannot be null or whitespaces"));
        }

        return Result.Sucsesfull<Ingridient>(new(name));
    }

    public Result ChangeName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            return Result.Failure(new Error("123", "new name cannot be null or whitespaces"));
        }

        Name = newName;
        
        return Result.Sucsesfull();
    }
}