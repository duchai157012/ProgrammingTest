using MassTransit;
using System;
using Shared.Contracts;
using System.Threading.RateLimiting;
using UserNotificationService.Consumers;

var builder = WebApplication.CreateBuilder(args);

var rabbitCfg = builder.Configuration.GetSection("RabbitMQ");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserRegisteredConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        var connection = builder.Configuration.GetConnectionString("rabbit");
        cfg.Host(connection);
        // Add message retry with exponential backoff: 3 retries
        cfg.UseMessageRetry(r => r.Exponential(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(2)));

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/notify/random", () =>
{
    var rnd = new Random();
    var id = Guid.NewGuid();
    var message = new
    {
        Id = id,
        Message = $"Random notification #{rnd.Next(1,1000)}",
        CreatedAt = DateTime.UtcNow
    };

    Console.WriteLine($"Notification created: {id}");
    return Results.Json(message);
});

app.Run();

public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
{
    public Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        Console.WriteLine($"New user registered: {context.Message.Email}");
        return Task.CompletedTask;
    }
}