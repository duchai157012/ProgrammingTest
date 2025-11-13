using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.DateAchievement;
using ProgrammingTest.Application.Interfaces;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.Queries.DateAchievement
{

    public record DateAchievementQuery(DateTime date) : IRequest<DateAchievementDTO>;
    public class DateAchievementQueryHandler : IRequestHandler<DateAchievementQuery, DateAchievementDTO>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DateAchievementQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<DateAchievementDTO> Handle(DateAchievementQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var achievements = await _context.DateAchievements
                .Where(a => a.Date == request.date && a.UserId.ToString() == userId)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<DateAchievementDTO>(achievements);
        }
    }
}
