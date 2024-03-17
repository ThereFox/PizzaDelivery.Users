using PizzaDelivery.GraphQL;


var builder = WebApplication.CreateBuilder(args);

builder.Services
.AddGraphQLApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL("api", "base");

app.Run();
