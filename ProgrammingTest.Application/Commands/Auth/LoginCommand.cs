using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.Commands.Auth;
using ProgrammingTest.Application.Interfaces;

namespace ProgrammingTest.Application.Commands.Auth
{
    public record LoginCommand(string Username, string Password) : IRequest<LoginResult>;
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }

        public static LoginResult Ok(string token) => new() { Success = true, Token = token };
        public static LoginResult Fail(string message) => new() { Success = false, Message = message };
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwt;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCommandHandler(IUserRepository userRepository, IJwtService jwt, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwt = jwt;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
                return LoginResult.Fail("User not found.");

            if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
                return LoginResult.Fail("Invalid password.");

            var token = await _jwt.GenerateToken(user);
            return LoginResult.Ok(token);
        }
    }
}
