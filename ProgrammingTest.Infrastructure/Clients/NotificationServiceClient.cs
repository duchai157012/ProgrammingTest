using ProgrammingTest.Application.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProgrammingTest.Infrastructure.Clients
{
    public class NotificationServiceClient : INotificationClient
    {
        private readonly HttpClient _httpClient;

        public NotificationServiceClient(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("UserNotificationService");
        }

        public async Task<string> SendRandomNotificationAsync()
        {
            var response = await _httpClient.PostAsync("/notify/random", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
