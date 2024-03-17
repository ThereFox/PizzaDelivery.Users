using PizzaDelivery.GraphQL.Auth.Attributes;
using HotChocolate.Authorization;
using Src.Core.App.Service;
using PizzaDelivery.GraphQL.DTO;
using PizzaDelivery.GraphQL.DTO.InputObjects;
using PizzaDelivery.Core.App.Service;
using PizzaDelivery.App.Service;
using PizzaDelivery.App.DTO;
using PizzaDelivery.GraphQL.Auth.Service;
using PizzaDelivery.Domain.Entitys;

namespace PizzaDelivery.GraphQL;

public class Mutation
{
    private readonly TokenAuthService _tokens;
    private readonly CustomerService _customers;
    private readonly ProductService _products;
    private readonly ModificationRepository _modification;
    private readonly OrderService _orders;
    private readonly TokenPouchService _pouchService;

    public Mutation()
    {
    }
    
    [AllowAnonymous]
    public async Task<DefaultResponse> Registrate(RegistrateRequest registrateInfo)
    {
        var regInfo = new CustomerRegistrateInfo(new Domain.Entitys.Phone(registrateInfo.PhoneNumber), registrateInfo.Name, registrateInfo.password);

        var registrateResult = await _tokens.Registrate(regInfo);

        if(registrateResult.IsSucsesfull == false)
        {
            return new DefaultResponse(123, registrateResult.ErrorInfo.Message);
        }

        var GetTokensResult = await _tokens.Authorise(regInfo.Phone, regInfo.Password);

        if(GetTokensResult.IsSucsesfull == false)
        {
            return new DefaultResponse(123, GetTokensResult.ErrorInfo.Message);
        }

        _pouchService.SendTokenToUser(GetTokensResult.ResultValue);

        return new DefaultResponse(1, "Sucsessfull");

    }
    
    [AllowAnonymous]
    public async Task<DefaultResponse> Authorise(AuthoriseRequest authoriseRequest)
    {
        var AuthoriseResult = await _tokens.Authorise( new Phone(authoriseRequest.PhoneNumber), authoriseRequest.Password);

        if(AuthoriseResult.IsSucsesfull == false)
        {
            return new DefaultResponse(1, AuthoriseResult.ErrorInfo.Message);
        }
        
        _pouchService.SendTokenToUser(AuthoriseResult.ResultValue);
        return new DefaultResponse(1, "Sucsessfull");
    }

    [CustomerAuthorise]
    public DefaultResponse CreateOrder(CreateOrderRequest createOrderRequest)
    {
        return null;
    }
    
    [CustomerAuthorise]
    public DefaultResponse CloseOwnedOrder(Guid id)
    {
        return null;
    }

    [AdminAuthorise]
    public DefaultResponse CloseOrder(Guid id)
    {
        return null;
    }

    [CustomerAuthorise]
    public DefaultResponse UpdateOwnOrder(UpdateOrderRequest updateOrderRequest)
    {
        return null;
    }

    [CustomerAuthorise]
    public DefaultResponse AddFeedback(AddFeedbackRequest addFeedbackRequest)
    {
        return null;
    }

    [AdminAuthorise]
    public DefaultResponse AddProduct(AddProductRequest addProductRequest)
    {
        return null;
    }
    
    [AdminAuthorise]
    public DefaultResponse ArchiveProduct(Guid id)
    {
        return null;
    }
    [AdminAuthorise]
    public DefaultResponse ReturnProductFromArchive(Guid id)
    {
        return null;
    }

}
