using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.BodyRecord;
using ProgrammingTest.Application.DTOs.DateAchievement;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Queries.DateAchievement
{

    public record BodyFatPercentageQuery(BodyRecordGroupByType Type) : IRequest<List<WeightBodyFatPercentage>>;
    public class BodyFatPercentageQueryHandler : IRequestHandler<BodyFatPercentageQuery, List<WeightBodyFatPercentage>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public BodyFatPercentageQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        }

        public async Task<List<WeightBodyFatPercentage>> Handle(BodyFatPercentageQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var currentYear = DateTime.UtcNow.Year;

            var records = await _context.BodyRecords
             .Where(a => a.UserId.ToString() == userId && a.Date.Year == currentYear)
             .ToListAsync(cancellationToken);

            IEnumerable<WeightBodyFatPercentage> result;

            switch (request.Type)
            {
                case BodyRecordGroupByType.Day:
                    result = records
                        .GroupBy(x => x.Date.Date)
                        .Select(g => new WeightBodyFatPercentage
                        {
                            Month = g.Key.ToString("yyyy-MM-dd"),
                            AverageBodyFatPercentage = g.Average(x => x.BodyFatPercentage),
                            AverageHeight = g.Average(x => x.Height)
                        });
                    break;

                case BodyRecordGroupByType.Week:
                    result = records
                        .GroupBy(x => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                            x.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
                        .Select(g => new WeightBodyFatPercentage
                        {
                            Month = $"Week {g.Key}",
                            AverageBodyFatPercentage = g.Average(x => x.BodyFatPercentage),
                            AverageHeight = g.Average(x => x.Height)
                        });
                    break;

                case BodyRecordGroupByType.Year:
                    result = records
                        .GroupBy(x => x.Date.Year)
                        .Select(g => new WeightBodyFatPercentage
                        {
                            Month = g.Key.ToString(),
                            AverageBodyFatPercentage = g.Average(x => x.BodyFatPercentage),
                            AverageHeight = g.Average(x => x.Height)
                        });
                    break;

                case BodyRecordGroupByType.Month:
                default:
                    result = records
                        .GroupBy(x => new { x.Date.Year, x.Date.Month })
                        .Select(g => new WeightBodyFatPercentage
                        {
                            Month = $"{g.Key.Year}-{g.Key.Month:D2}",
                            AverageBodyFatPercentage = g.Average(x => x.BodyFatPercentage),
                            AverageHeight = g.Average(x => x.Height)
                        });
                    break;
            }

            return result.OrderBy(x => x.Month).ToList();
        }
    }
}
