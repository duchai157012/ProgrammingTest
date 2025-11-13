using MassTransit;
using MediatR;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Domain.Entities;
using Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.Commands.Register
{
    public interface RegisterCommandHandler
    {
        public record RegisterCommand(string Username, string Email, string Password) : IRequest<RegisterResult>;

        public class RegisterResult
        {
            public bool Success { get; set; }
            public string? Token { get; set; }
            public string? Message { get; set; }

            public static RegisterResult Ok(string token) => new() { Success = true, Token = token };
            public static RegisterResult Fail(string message) => new() { Success = false, Message = message };
        }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResult>
        {
            private readonly IUserRepository _userRepository;
            private readonly IPasswordHasher _passwordHasher;
            private readonly IJwtService _tokenService;
            private readonly IPublishEndpoint _publishEndpoint;

            public RegisterCommandHandler(
                IUserRepository userRepository,
                IPasswordHasher passwordHasher,
                IJwtService tokenService,
                IPublishEndpoint publishEndpoint)
            {
                _userRepository = userRepository;
                _passwordHasher = passwordHasher;
                _tokenService = tokenService;
                _publishEndpoint = publishEndpoint;
            }

            public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var existing = await _userRepository.GetByUsernameAsync(request.Username);
                if (existing != null)
                    return RegisterResult.Fail("Username already exists.");

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Username = request.Username,
                    Email = request.Email,
                    PasswordHash = _passwordHasher.HashPassword(request.Password)
                };

                await _userRepository.AddAsync(user);

                await _publishEndpoint.Publish(new UserRegisteredEvent
                {
                    UserId = user.Id,
                    Email = user.Email,
                    RegisteredAt = DateTime.UtcNow
                }, cancellationToken);

                var token = await _tokenService.GenerateToken(user);
                return RegisterResult.Ok(token);
            }
        }
    }
}
