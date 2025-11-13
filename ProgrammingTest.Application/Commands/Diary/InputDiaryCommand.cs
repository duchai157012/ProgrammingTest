using MediatR;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Diagnostics.Metrics;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Commands.InputMeal
{
    public class InputDiaryCommand : IRequest<Guid>
    {
        public string Thoughts { get; set; }
    }

    public class InputDiaryCommandHandler : IRequestHandler<InputDiaryCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public InputDiaryCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Guid> Handle(InputDiaryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Diary
            {
                Id = Guid.NewGuid(),
                Date = DateTime.UtcNow,
                Thoughts = request.Thoughts,
                UserId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"))
            };

            _context.Diaries.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
