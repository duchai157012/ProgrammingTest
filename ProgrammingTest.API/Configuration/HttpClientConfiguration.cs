using MassTransit.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;
using Polly.Extensions.Http;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Infrastructure.Clients;
using System;
using System.Net;
using System.Net.Http;

namespace ProgrammingTest.API.Configuration
{
    public static class HttpClientConfiguration
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient()
            .ConfigureHttpClientDefaults(http =>
                http.AddStandardResilienceHandler(options =>
                {
                    options.Retry.MaxRetryAttempts = 3;            // default: 3
                    options.Retry.Delay = TimeSpan.FromSeconds(2); // exponential backoff base
                    options.CircuitBreaker.SamplingDuration = TimeSpan.FromSeconds(30);
                }));

            // Notification service client with retry + circuit-breaker
            services.AddHttpClient("UserNotificationService")
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("UserService:BaseUrl") ?? "http://localhost:5113");
            })
            .RemoveAllResilienceHandlers()
            .AddResilienceHandler("custom", pipeline =>
            {
                pipeline.AddTimeout(TimeSpan.FromSeconds(40));

                pipeline.AddRetry(new HttpRetryStrategyOptions
                {
                    MaxRetryAttempts = 3,
                    BackoffType = DelayBackoffType.Exponential,
                    UseJitter = true,
                    Delay = TimeSpan.FromMilliseconds(500)
                });

                pipeline.AddTimeout(TimeSpan.FromSeconds(10));
            });

            return services;
        }

        public static IHttpClientBuilder RemoveAllResilienceHandlers(this IHttpClientBuilder builder)
        {
            builder.ConfigureAdditionalHttpMessageHandlers(static (handlers, _) =>
            {
                for (int i = handlers.Count - 1; i >= 0; i--)
                {
                    if (handlers[i].GetType().GetTypeName().Contains("ResilienceHandler"))
                    {
                        handlers.RemoveAt(i);
                    }
                }
            });
            return builder;
        }
    }
}
