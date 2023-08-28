using CacheExample.Adaptor;
using CacheExample.Decorator;
using CacheExample.Interface;
using CacheExample.Service;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddSingleton<ICache, MemoryCacheAdapter>();
builder.Services.Decorate<ICache, LoggingCacheDecorator>();
builder.Services.AddTransient<ExampleService>();


builder.Services.AddControllers();
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
