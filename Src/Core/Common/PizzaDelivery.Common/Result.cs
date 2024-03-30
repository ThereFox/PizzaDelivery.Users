namespace PizzaDelivery.Src.Core.Common;

public class Result
{
    public Error ErrorInfo {get; init;}
    public bool IsSucsesfull { get; init; }

    public Result(bool isSucsesfull, Error error)
    {
        if(isSucsesfull && error.Code != Error.None.Code)
        {
            throw new InvalidOperationException();
        }
        if(!isSucsesfull && error.Code == Error.None.Code)
        {
            throw new InvalidOperationException();
        }

        IsSucsesfull = isSucsesfull;
        ErrorInfo = error;
    }

    public static Result Sucsesfull()
    {
        return new Result(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new Result(false, error);
    }
        public static Result<TValue> Sucsesfull<TValue>(TValue result)
    {
        return new Result<TValue>(result, true, Error.None);
    }
    public static Result<TValue> Failure<TValue>(Error error)
    {
        return new Result<TValue>(default!, false, error);
    }

}