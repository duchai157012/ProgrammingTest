using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.DTOs.DateAchievement
{
    public class DateAchievementDTO
    {
        public Guid Id { get; set; }
        public Guid ProfileId { get; set; }
        public DateTime Date { get; set; }
        public double TotalGoalsCompleted { get; set; }
        public double TotalGoalsSet { get; set; }
    }
}
