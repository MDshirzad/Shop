using System.Reflection;
using Carter;
using FluentValidation;
using Shop.Catalog;
using Shop.Catalog.Application.Product.Contracts;
using Shop.Catalog.Application.Product;
using Shop.Catalog.Domain.Products;
using Shop.Catalog.Infrastructure.Persistence;
using Shop.Catalog.Presentation.Contracts.Dtos;
using Shop.Catalog.Presentation.Contracts.Validators;
using Shop.Middlewares.ExceptionHandler;
using Shop.Catalog.Infrastructure;
using static CSharpFunctionalExtensions.Result;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddCatalogtDependencyInjection(builder.Configuration);
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseExceptionHandler(); 
app.MapCarter();
app.Run();
 
