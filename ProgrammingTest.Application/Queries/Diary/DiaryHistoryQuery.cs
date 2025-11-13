using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.Diary;
using ProgrammingTest.Application.DTOs.Meal;
using ProgrammingTest.Application.Interfaces;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Queries.InputMeal
{
    public class DiaryHistoryQuery : IRequest<List<DiaryDTO>>
    {
    }

    public class DiaryHistoryQueryHandler : IRequestHandler<DiaryHistoryQuery, List<DiaryDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapp;

        public DiaryHistoryQueryHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapp)
        {
            _context = context;
            _currentUser = currentUser;
            _mapp = mapp;
        }

        public async Task<List<DiaryDTO>> Handle(DiaryHistoryQuery query, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"));
            var meals = await _context.Diaries
                .Where(m => m.UserId == userId)
                .ToListAsync(cancellationToken);

            return _mapp.Map<List<DiaryDTO>>(meals);
        }
    }
}
