using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProgrammingTest.Application.DTOs.ColumnItem;
using ProgrammingTest.Application.DTOs.Meal;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Diagnostics.Metrics;

namespace ProgrammingTest.Application.Queries.InputMeal
{
    public class AllColumnItemsQuery : IRequest<List<ColumnItemDTO>>
    {
    }

    public class AllColumnItemsQueryHandler : IRequestHandler<AllColumnItemsQuery, List<ColumnItemDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapp;

        public AllColumnItemsQueryHandler(IApplicationDbContext context, IMapper mapp)
        {
            _context = context;
            _mapp = mapp;
        }

        public async Task<List<ColumnItemDTO>> Handle(AllColumnItemsQuery query, CancellationToken cancellationToken)
        {
            var items = await _context.ColumnItems
                .ToListAsync(cancellationToken);

            return _mapp.Map<List<ColumnItemDTO>>(items);
        }
    }
}
