using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using StackSpot.ErrorHandler;
using CursoResidencia.Application.Common.StackSpot;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddStackSpot(builder.Configuration, builder.Environment);

builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks();
builder.Services.AddControllers()
       .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
       .AddJsonOptions(x =>
       {
            x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
       });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CursoResidencia.Api", Version = "v1" });
});

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoResidencia.Api v1"));

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseErrorHandler();
app.UseRouting();

app.MapControllers();

app.UseStackSpot(builder.Configuration, builder.Environment);

app.Run();