
using AutomaticPaymentReminder.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddPersistenceServices(builder.Configuration);
var app = builder.Build();



app.UseHttpsRedirection();



app.Run();

