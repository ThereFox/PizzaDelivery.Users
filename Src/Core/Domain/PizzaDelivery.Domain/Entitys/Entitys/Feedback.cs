using CSharpFunctionalExtensions;
using Domain.Ordering.ValueObjects;
using PizzaDelivery.Src.Core.Common;
using Result = PizzaDelivery.Src.Core.Common.Result;

namespace Domain.Ordering;

public class Feedback : Entity<Guid>
{
    public FeedbackScore Score { get; private set; }
    public string Comment { get; private set; }
    public DateTime LastUpdate { get; private set; }
    
    public Order Order { get; }

    protected Feedback(Guid id, FeedbackScore score, string comment, Order order)
    {
        Id = id;
        Score = score;
        Comment = comment;
        Order = order;
        LastUpdate = DateTime.Now;
    }

    public Result ChangeScore(FeedbackScore newScore)
    {
        if (Score == newScore)
        {
            return Result.Failure(new Error("123", "havent changes"));
        }
        
        Score = newScore;
        LastUpdate = DateTime.Now;
        
        return Result.Sucsesfull();
    }

    public Result ChangeComment(string newComment)
    {
        if (string.IsNullOrWhiteSpace(newComment))
        {
            return Result.Failure(new Error("123", "comment null or whitespaces"));
        }
        
        Comment = newComment.Trim();
        LastUpdate = DateTime.Now;

        return Result.Sucsesfull();
    }

    public static Result Create(Guid id, FeedbackScore score, string comment, Order order)
    {
        if (string.IsNullOrWhiteSpace(comment))
        {
            return Result.Failure<Feedback>(new Error("123", "comment null or whitespaces"));
        }

        if (order == null)
        {
            return Result.Failure<Feedback>(new Error("123", "order cannot be null"));
        }
        
        return Result.Sucsesfull<Feedback>(new Feedback(id, score, comment, order));
    }
    
}