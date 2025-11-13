using Polly;
using Polly.Retry;
using ProgrammingTest.Application.DTOs.User;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Infrastructure.Clients
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public UserServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // Retry policy
            _retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid userId)
        {
            var fallback = Policy<UserDTO>.Handle<Exception>()
                .FallbackAsync(new UserDTO
                {
                    Id = userId,
                    Name = "Unknown",
                    Email = "unknown@example.com"
                });

            return await fallback.ExecuteAsync(async () =>
            {
                var response = await _retryPolicy.ExecuteAsync(() =>
                    _httpClient.GetAsync($"/users/{userId}")
                );

                response.EnsureSuccessStatusCode();
                var user = await response.Content.ReadFromJsonAsync<UserDTO>();
                return user!;
            });
        }
    }
}
