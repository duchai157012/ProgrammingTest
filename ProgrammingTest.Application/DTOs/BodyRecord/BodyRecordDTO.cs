using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.DTOs.BodyRecord
{
    public class BodyRecordDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double BodyFatPercentage { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double MuscleMass { get; set; }
        public double BoneMass { get; set; }
        public double Bmi { get; set; }
        public Guid UserId { get; set; }
    }
}
