using PizzaDelivery.GraphQL;
using PizzaDelivery.App;
using PizzaDeliveryApp.DAL;
using ISTUTimeTable.Src.Infrastructure.Authorise.DIService;
using PizzaDelivery.SequreAlghoritms;


var builder = WebApplication.CreateBuilder(args);

builder.Services

    .AddSequreAlghoritms()
    .AddEFDAL()
    .AddCustomJWTService()
    .AddAppServices()
    .AddGraphQLApi()
    .AddHttpContextAccessor()
    ;

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL("/api", "base");

app.Run();
