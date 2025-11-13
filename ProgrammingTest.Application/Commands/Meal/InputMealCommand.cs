using MediatR;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Enums;
using ProgrammingTest.Application.Interfaces;
using System;
using System.Diagnostics.Metrics;
using Shared.Interfaces;

namespace ProgrammingTest.Application.Commands.InputMeal
{
    public class InputMealCommand : IRequest<Guid>
    {
        public MealType MealType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public DateTime Date { get; set; }
    }

    public class InputMealCommandHandler : IRequestHandler<InputMealCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public InputMealCommandHandler(IApplicationDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public async Task<Guid> Handle(InputMealCommand request, CancellationToken cancellationToken)
        {
            var entity = new Meal
            {
                Id = Guid.NewGuid(),
                MealType = request.MealType,
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Calories = request.Calories,
                Protein = request.Protein,
                Carbohydrates = request.Carbohydrates,
                Fat = request.Fat,
                Date = request.Date,
                UserId = Guid.Parse(_currentUser.UserId ?? throw new InvalidOperationException("User ID is null"))
            };

            _context.Meals.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
