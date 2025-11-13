using ProgrammingTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.DTOs.Meal
{
    public class MealDTO
    {
        public Guid Id { get; set; }
        public MealType MealType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
