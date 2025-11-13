using System.Threading.Tasks;

namespace ProgrammingTest.Application.Interfaces
{
    public interface INotificationClient
    {
        /// <summary>
        /// Calls notification service to create/send a random/simple notification and returns the response body as string.
        /// </summary>
        Task<string> SendRandomNotificationAsync();
    }
}
