using Azure.Messaging.ServiceBus;
using SampleProject.Application.Features.OrderDetail.Handler;
using SampleProject.Application.Mapper;
using SampleProject.Application.ViewModels;
using SampleProject.Domain.Interface;
using SampleProject.Domain.Models;
using SampleProject.Domain.Service;
using SampleProject.Infrastructure.Data;
using SampleProject.Infrastructure.DataAccess;
using SampleProject.Infrastructure.Repositories;
using SampleProject.Infrastructure.ServiceBus.Queue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddAutoMapper(typeof(OrderItemsMappingProfile));
builder.Services.AddScoped<IOrderDetailsRepository<OrderItems>, OrderItemsRepository>();
builder.Services.AddScoped<IServiceBusSender<OrderItemsResponse>, ServiceBusSenderQueue>();
builder.Services.AddScoped<OrderDetailsDataAccess>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllOrderItemsHandler).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
