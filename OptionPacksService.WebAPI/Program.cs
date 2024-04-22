using System.Reflection;
using OptionPacksService.ApplicationService.Mappings;
using OptionPacksService.DataAccess.Interfaces;
using OptionPacksService.DataAccess.Repositories;
using OptionPacksService.Domain.Context;
using SharedCore.Configuration;
using SharedCore.Configuration.MassTransit;
using SharedCore.Extensions;
using SharedCore.Implementations;
using SharedCore.Interfaces;
using ApplicationServiceMarker = OptionPacksService.ApplicationService.Marker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(OptionPacksMappingProfile));
builder.Services.CoreAddDbContext<ApplicationDbContext>();
builder.Services.AddBaseServices(Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);
builder.Services.AddBaseInfrastructureServices();

builder.Services.ConfigureMassTransit(new MassTransitConfiguration(builder.Configuration),
    Assembly.GetAssembly(typeof(ApplicationServiceMarker))!);

AddDependencies(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    services.AddScoped<IMessageService, MessageService>();
    services.AddScoped<IOptionPacksOrderRepository, OptionPacksOrderRepository>();
}

#endregion