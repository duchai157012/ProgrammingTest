using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddHttpClient("UserNotificationService", client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("UserService:BaseUrl") ?? "http://localhost:5113");
                client.Timeout = TimeSpan.FromSeconds(15);
            });
            //.AddHttpMessageHandler<OutboundDiagnosticsHandler>()
            //.AddPolicyHandler(GetRetryPolicy())
            //.AddPolicyHandler(GetCircuitBreakerPolicy());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {

            var jitterer = new Random();
            return HttpPolicyExtensions
                .HandleTransientHttpError() // 5xx, 408 + HttpRequestException
                .OrResult(msg => msg.StatusCode == HttpStatusCode.TooManyRequests) // 429
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // 2,4,8,16,32
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 250)),
                    onRetry: (outcome, delay, attempt, context) =>
                    {
                        Console.WriteLine($"[Retry] Attempt {attempt}, waiting {delay}. " +
                                          $"Reason: {(outcome.Exception != null ? outcome.Exception.Message : ((int)outcome.Result.StatusCode + " " + outcome.Result.StatusCode))}");
                    });

        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {

            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .OrResult(msg => (int)msg.StatusCode == 429)
                    .CircuitBreakerAsync(
                        handledEventsAllowedBeforeBreaking: 5,
                        durationOfBreak: TimeSpan.FromSeconds(30),
                        onBreak: (outcome, breakDelay) =>
                        {
                            Console.WriteLine($"[Circuit] OPEN for {breakDelay}. Reason: " +
                                              $"{(outcome.Exception != null ? outcome.Exception.Message : ((int)outcome.Result.StatusCode + " " + outcome.Result.StatusCode))}");
                        },
                        onReset: () => Console.WriteLine("[Circuit] CLOSED"),
                        onHalfOpen: () => Console.WriteLine("[Circuit] HALF-OPEN: next call is a trial"));

        }

        public sealed class OutboundDiagnosticsHandler : DelegatingHandler
        {
            private readonly ILogger<OutboundDiagnosticsHandler> _logger;

            public OutboundDiagnosticsHandler(ILogger<OutboundDiagnosticsHandler> logger)
                => _logger = logger;

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
            {
                try
                {
                    return await base.SendAsync(request, ct);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Outbound HTTP failed: {Type}", ex.GetType().FullName);
                    throw;
                }
            }
        }

    }
}
