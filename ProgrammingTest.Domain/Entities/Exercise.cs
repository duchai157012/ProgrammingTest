using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingTest.Domain.Enums;

namespace ProgrammingTest.Domain.Entities
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; }
        public ExerciseType Type { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
