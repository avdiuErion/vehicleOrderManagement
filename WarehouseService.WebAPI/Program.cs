using System.Reflection;
using SharedCore.Configuration;
using SharedCore.Configuration.MassTransit;
using SharedCore.Extensions;
using SharedCore.Implementations;
using SharedCore.Interfaces;
using Warehouse.DataAccess.Interfaces;
using Warehouse.DataAccess.Repositories;
using Warehouse.Domain.Context;
using WarehouseService.ApplicationService.Interfaces;
using WarehouseService.ApplicationService.Mappings;
using ApplicationServiceMarker = WarehouseService.ApplicationService.Marker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(WarehouseMappingProfile));
builder.Services.AddBaseServices(Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);
builder.Services.CoreAddDbContext<ApplicationDbContext>();
builder.Services.AddBaseInfrastructureServices();

builder.Services.ConfigureMassTransit(new MassTransitConfiguration(builder.Configuration),
    Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);

AddDependencies(builder.Services);

SerilogConfiguration.ConfigureSerilog();

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
    services.AddScoped<IWarehouseService, WarehouseService.ApplicationService.Services.WarehouseService>();
    services.AddScoped<IMessageService, MessageService>();
    services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
    services.AddScoped<IVehicleRepository, VehicleRepository>();
}

#endregion