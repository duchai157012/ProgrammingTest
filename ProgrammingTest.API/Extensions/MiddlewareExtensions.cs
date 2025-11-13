using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using ProgrammingTest.API.Middleware;

namespace ProgrammingTest.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication ConfigureMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
