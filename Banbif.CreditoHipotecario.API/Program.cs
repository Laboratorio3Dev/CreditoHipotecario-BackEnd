using Banbif.CreditoHipotecario.API.Middlewares;
using BanBif.CreditoHipotecario.Application;
using BanBif.CreditoHipotecario.Application.Common.Behaviors;
using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Infrastructure;
using BanBif.CreditoHipotecario.Infrastructure.Persistence;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
});

var configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDapperExecutor, DapperExecutor>();


builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(TransactionBehavior<,>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ManejadorErrorMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
