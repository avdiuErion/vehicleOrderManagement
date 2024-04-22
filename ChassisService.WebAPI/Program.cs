using System.Reflection;
using ChassisService.ApplicationService.Mappings;
using ChassisService.Domain.Context;
using ChassissService.DataAccess.Interfaces;
using ChassissService.DataAccess.Repositories;
using SharedCore.Configuration;
using SharedCore.Configuration.MassTransit;
using SharedCore.Extensions;
using SharedCore.Implementations;
using SharedCore.Interfaces;
using ApplicationServiceMarker = ChassisService.ApplicationService.Marker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ChassisMappingProfile));
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
    services.AddScoped<IChassisOrderRepository, ChassisOrderRepository>();
}

#endregion