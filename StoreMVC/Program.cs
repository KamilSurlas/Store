using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StoreMVC.BLL.Query;
using StoreMVC.BLL.Validator;
using StoreMVC.DataAccess;
using StoreMVC.Model;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>();
builder.Services.AddScoped<IValidator<ProductQuery>, ProductQueryValidator>();
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
