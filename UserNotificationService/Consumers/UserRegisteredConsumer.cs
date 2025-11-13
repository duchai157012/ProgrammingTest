using MassTransit;
using Shared.Contracts;

namespace UserNotificationService.Consumers
{
    public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
        {
            var msg = context.Message;

            Console.WriteLine("Received UserRegisteredEvent:");
            Console.WriteLine($" - UserId: {msg.UserId}");
            Console.WriteLine($" - Email: {msg.Email}");
            Console.WriteLine($" - RegisteredAt: {msg.RegisteredAt}");

            //Send email (simulated)
            await Task.Delay(500);

            Console.WriteLine($"Sent welcome email to {msg.Email}\n");
        }
    }
}
