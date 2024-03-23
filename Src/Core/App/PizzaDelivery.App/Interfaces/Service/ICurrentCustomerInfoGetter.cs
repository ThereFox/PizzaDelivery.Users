using PizzaDelivery.App.DTO;
using PizzaDelivery.Src.Core.Common;

namespace PizzaDelivery.App.Interfaces.Service;

public interface ICurrentCustomerInfoGetter
{
    public Result<AuthTokenUserInfo> Get();
}
