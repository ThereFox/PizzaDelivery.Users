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
using PizzaDelivery.Domain.Entitys.Order;
using PizzaDelivery.App.Interfaces.Service;
using PizzaDelivery.GraphQL.DTO.InputObjects.CreateOrderRequestEntitys;

namespace PizzaDelivery.GraphQL;

public class Mutation
{
    private readonly TokenAuthService _tokens;
    private readonly CustomerService _customers;
    private readonly FeedbackService _feedbacks;
    private readonly ProductService _products;
    private readonly ModificationService _modification;
    private readonly OrderService _orders;
    private readonly TokenPouchService _pouchService;
    private readonly ICurrentCustomerInfoGetter _currentService;

    public Mutation(
        TokenAuthService tokenService,
        CustomerService customerService,
        ProductService productService,
        ModificationService modificationService,
        OrderService orderService,
        TokenPouchService pouchService,
        FeedbackService feedbackService
        )
    {
        _tokens = tokenService;
        _customers = customerService;
        _products = productService;
        _modification = modificationService;
        _orders = orderService;
        _pouchService = pouchService;
        _feedbacks = feedbackService;
    }
    
    [AllowAnonymous]
    public async Task<DefaultResponse> Registrate(RegistrateRequest registrateInfo)
    {
        var regInfo = new CustomerRegistrateInfo(new Domain.Entitys.Phone(registrateInfo.PhoneNumber), registrateInfo.Name, registrateInfo.password);

        var registrateResult = await _tokens.Registrate(regInfo);

        if(registrateResult.IsSucsesfull == false)
        {
            return DefaultResponse.FromResult(registrateResult);
        }

        var getTokensResult = await _tokens.Authorise(regInfo.Phone, regInfo.Password);

        if(getTokensResult.IsSucsesfull == false)
        {
            return DefaultResponse.FromResult(getTokensResult);
        }

        _pouchService.SendTokenToUser(getTokensResult.ResultValue);

        return DefaultResponse.Ok;

    }
    
    [AllowAnonymous]
    public async Task<DefaultResponse> Authorise(AuthoriseRequest authoriseRequest)
    {
        var AuthoriseResult = await _tokens.Authorise( new Phone(authoriseRequest.PhoneNumber), authoriseRequest.Password);

        if(AuthoriseResult.IsSucsesfull == false)
        {
            return DefaultResponse.FromResult(AuthoriseResult);
        }
        
        _pouchService.SendTokenToUser(AuthoriseResult.ResultValue);
        return DefaultResponse.Ok;
    }

    [CustomerAuthorise]
    public async Task<DefaultResponse> CreateOrder(CreateOrderRequest createOrderRequest)
    {
        var inputAddress = createOrderRequest.Addres;

        var Address = new Domain.Entitys.Order.Address()
        { 
            City = inputAddress.City,
            House = inputAddress.HouseNumber,
            Room = inputAddress.RoomNumber,
            Street = inputAddress.Street
        };

        var products = createOrderRequest.Products.ConvertAll(
            ex => new OrderedProduct()
            {
                Id = ex.Id,
                AppliedModification = ex.ModificationIds.ConvertAll(
                    guid => new Modification() { Id = guid }
                )
            }
        );

        var order = new Order() {
            Address = Address,
            Products = products,
            Comment = createOrderRequest.Comment
        };

        var createOrderResult = await _orders.CreateOrderFromCurrentUser(order);

        return DefaultResponse.FromResult(createOrderResult);

    }
    
    [CustomerAuthorise]
    public async Task<DefaultResponse> CloseOwnedOrder(Guid id)
    {
        var closeOrderResult = await _orders.CloseOwnerById(id);

        return DefaultResponse.FromResult(closeOrderResult);
    }

    [AdminAuthorise]
    public async Task<DefaultResponse> CloseOrder(Guid id)
    {
        var closeOrderResult = await _orders.CloseById(id);

        return DefaultResponse.FromResult(closeOrderResult);
    }

    [CustomerAuthorise]
    public async Task<DefaultResponse> UpdateOwnOrder(UpdateOrderRequest updateOrderRequest)
    {
        return null;
    }

    [CustomerAuthorise]
    public async Task<DefaultResponse> AddFeedback(AddFeedbackRequest addFeedbackRequest)
    {
        var feedback = new Feedback()
        {
            Score = addFeedbackRequest.Score,
            Message = addFeedbackRequest.Message
        };
        var orderId = addFeedbackRequest.OrderId;

        var addOrderResult = await _feedbacks.AddToOrder(orderId, feedback);

        return DefaultResponse.FromResult(addOrderResult);
    }

    [AdminAuthorise]
    public async Task<DefaultResponse> AddProduct(AddProductRequest addProductRequest)
    {
        var product = new Product()
        {
            ContainingIngridientsWeight = new Dictionary<Ingridient, int>(
                addProductRequest.IngridientsContaining.ConvertAll(
                    ex => new KeyValuePair<Ingridient, int>(
                        new Ingridient() {Id = ex.IngridientId},ex.NormalWeight
                        )
                        )
                    ),
            Price = addProductRequest.Price,
            Name = addProductRequest.Name,
            Description = addProductRequest.Description,
            IsArchived = addProductRequest.IsStartInArchive
        };

        var addProductResult = await _products.Create(product);

        return DefaultResponse.FromResult(addProductResult);
    }
    
    [AdminAuthorise]
    public async Task<DefaultResponse> ArchiveProduct(Guid id)
    {
        var archiveProductResult = await _products.Archive(id);

        return DefaultResponse.FromResult(archiveProductResult);
    }
    [AdminAuthorise]
    public async Task<DefaultResponse> ReturnProductFromArchive(Guid id)
    {
        var returnProductFromArchiveResult = await _products.ReturnProductFromArchive(id);

        return DefaultResponse.FromResult(returnProductFromArchiveResult);
    }

}
