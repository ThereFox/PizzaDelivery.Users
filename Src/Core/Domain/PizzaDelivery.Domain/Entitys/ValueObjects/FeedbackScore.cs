using CSharpFunctionalExtensions;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering.ValueObjects;

public class FeedbackScore : ValueObject
{
    public static FeedbackScore Sad => new(1);
    public static FeedbackScore Bad => new(2);
    public static FeedbackScore OK => new(3);
    public static FeedbackScore Exelent => new(4);
    public static FeedbackScore Wonderfull => new(5);

    
    public int Value { get; }

    protected FeedbackScore(int value)
    {
        Value = value;
    }

    public static PizzaDelivery.Src.Core.Common.Result<FeedbackScore> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<FeedbackScore>(new Error("123", "Score out of range"));
        }

        return Result.Sucsesfull<FeedbackScore>(new(value));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Value;
    }
    
}