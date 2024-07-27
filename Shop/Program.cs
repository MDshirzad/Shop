using System.Reflection;
using Carter;
using FluentValidation;
using Shop.Catalog.Presentation.Contracts.Dtos;
using Shop.Catalog.Presentation.Contracts.Validators;
using Shop.Middlewares.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

var assemblyType=Assembly.GetAssembly(typeof(Program));

builder.Services.AddValidatorsFromAssembly(assemblyType);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();
builder.Services.AddAutoMapper(assemblyType);
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(); 
app.MapCarter();
app.Run();
 
