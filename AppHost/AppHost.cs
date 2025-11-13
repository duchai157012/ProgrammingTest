using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var rabbitMq = builder.AddRabbitMQ("rabbit")
    .WithManagementPlugin();

var userService = builder.AddProject<Projects.ProgrammingTest_API>("programmingtest").WithReference(rabbitMq);

var notificationService = builder.AddProject<Projects.UserNotificationService>("notificationservice").WithReference(rabbitMq);

builder.Build().Run();
