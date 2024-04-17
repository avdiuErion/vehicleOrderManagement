using System.Reflection;
using OrderService.ApplicationService.Mapping;
using SharedCore.Configuration;
using SharedCore.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));

SerilogConfiguration.ConfigureSerilog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestCorrelationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
