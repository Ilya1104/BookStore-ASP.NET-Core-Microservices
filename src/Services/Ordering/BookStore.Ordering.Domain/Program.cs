using BookStore.Ordering.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddData();
var app = builder.Build();

app.Run();