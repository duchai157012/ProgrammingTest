using ProgrammingTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.DTOs.Exercise
{
    public class ExerciseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public double CaloriesBurned { get; set; }
        public ExerciseType Type { get; set; }
        public ExerciseIntensity Intensity { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
    }
}
