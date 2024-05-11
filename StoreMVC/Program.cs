using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StoreMVC.BLL.Query;
using StoreMVC.DataAccess;
using StoreMVC.Model;
using StoreMVC.BLL;
using StoreMVC.BLL.Validator;
using StoreMVC.BLL.Repository.Product;
using StoreMVC.BLL_EF.Repository;
using StoreMVC.BLL.Repository.Basket;
using StoreMVC.BLL_EF;
using StoreMVC.BLL.Repository.Order;
using StoreMVC.BLL_EF.Middleware;
using FluentValidation.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>();
builder.Services.AddScoped<IValidator<ProductQuery>, ProductQueryValidator>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();
app.UseCors(optBuilder => optBuilder
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin()
                                .Build());
app.UseMiddleware<ErrorHandlingMiddleware>();
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
