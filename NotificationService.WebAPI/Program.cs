using System.Reflection;
using SharedCore.Configuration;
using SharedCore.Configuration.MassTransit;
using SharedCore.Extensions;
using ApplicationServiceMarker = NotificationService.ApplicationService.Marker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBaseServices(Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);
builder.Services.AddBaseInfrastructureServices();

builder.Services.ConfigureMassTransit(new MassTransitConfiguration(builder.Configuration),
    Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);

AddServicesAndRepos(builder.Services);

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

#region Repos and Services extension

void AddServicesAndRepos(IServiceCollection services)
{
    // services.AddScoped<IWarehouseService, WarehouseService.ApplicationService.Services.WarehouseService>();
    // services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
}

#endregion