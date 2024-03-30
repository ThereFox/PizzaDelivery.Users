namespace PizzaDelivery.Src.Core.Common;

public sealed class Error
{
    public string Code { get; init; }
    public string Message { get; init; }

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error None => new Error("-","None");
}