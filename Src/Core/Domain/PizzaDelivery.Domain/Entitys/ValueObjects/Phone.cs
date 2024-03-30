using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;
namespace Domain.Ordering.ValueObjects;

public class Phone : ValueObject
{
    public const string phoneRegExp = "+7[0-9]{10}";
    
    public string Number { get; }

    protected Phone(string number)
    {
        Number = number;
    }

    public static PizzaDelivery.Src.Core.Common.Result<Phone> Create(string number)
    {
        if (Regex.IsMatch(number, phoneRegExp) == false)
        {
            return Result.Failure<Phone>(new Error("123", "is not valid phone number"));
        }

        return Result.Sucsesfull<Phone>(new(number));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Number;
    }
}