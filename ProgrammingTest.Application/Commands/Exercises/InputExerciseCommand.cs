using MediatR;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Diagnostics.Metrics;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Commands.InputMeal
{
    public class InputExerciseCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; }
        public ExerciseType Type { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public DateTime Date { get; set; }
    }

    public class InputExerciseCommandHandler : IRequestHandler<InputExerciseCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public InputExerciseCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Guid> Handle(InputExerciseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Exercise
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                CaloriesBurned = request.CaloriesBurned,
                Type = request.Type,
                Intensity = request.Intensity,
                Date = request.Date,
                UserId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"))
            };

            _context.Exercises.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
