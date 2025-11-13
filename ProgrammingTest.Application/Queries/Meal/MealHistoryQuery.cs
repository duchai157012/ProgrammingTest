using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.Meal;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Diagnostics.Metrics;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Queries.InputMeal
{
    public class MealHistoryQuery : IRequest<List<MealDTO>>
    {
    }

    public class MealHistoryQueryHandler : IRequestHandler<MealHistoryQuery, List<MealDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapp;

        public MealHistoryQueryHandler(IApplicationDbContext context, ICurrentUserService currentUser, IMapper mapp)
        {
            _context = context;
            _currentUser = currentUser;
            _mapp = mapp;
        }

        public async Task<List<MealDTO>> Handle(MealHistoryQuery query, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"));
            var meals = await _context.Meals
                .Where(m => m.UserId == userId)
                .ToListAsync(cancellationToken);

            return _mapp.Map<List<MealDTO>>(meals);
        }
    }
}
