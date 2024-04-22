using System.Reflection;
using OrderService.ApplicationService.Mapping;
using OrderService.DataAccess.Implementations;
using OrderService.DataAccess.Interfaces;
using OrderService.Domain.Context;
using SharedCore.Clients.Implementations;
using SharedCore.Clients.Interfaces;
using SharedCore.Configuration;
using SharedCore.Configuration.MassTransit;
using SharedCore.Extensions;
using SharedCore.Implementations;
using SharedCore.Interfaces;
using ApplicationServiceMarker = OrderService.ApplicationService.Marker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddBaseServices(Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);
builder.Services.CoreAddDbContext<ApplicationDbContext>();
builder.Services.AddBaseInfrastructureServices();

builder.Services.ConfigureMassTransit(new MassTransitConfiguration(builder.Configuration),
    Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);

AddDependencies(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddSharedConfiguration();
app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();

#region Dependencies

void AddDependencies(IServiceCollection services)
{
    services.AddScoped<IWarehouseClient, WarehouseClient>();
    services.AddScoped<IMessageService, MessageService>();
    services.AddScoped<IOrderRepository, OrderRepository>();
}

#endregion
