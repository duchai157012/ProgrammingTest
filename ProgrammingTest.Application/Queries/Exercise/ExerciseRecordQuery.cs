using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.Exercise;
using ProgrammingTest.Application.Interfaces;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Queries.ExerciseRecord
{
    public class ExerciseRecordQuery : IRequest<List<ExerciseDTO>>
    {
    }

    public class ExerciseRecordQueryHandler : IRequestHandler<ExerciseRecordQuery, List<ExerciseDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapp;

        public ExerciseRecordQueryHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapp)
        {
            _context = context;
            _currentUser = currentUser;
            _mapp = mapp;
        }

        public async Task<List<ExerciseDTO>> Handle(ExerciseRecordQuery query, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"));
            var exercises = await _context.Exercises
                .Where(m => m.UserId == userId)
                .ToListAsync(cancellationToken);

            return _mapp.Map<List<ExerciseDTO>>(exercises);
        }
    }
}
