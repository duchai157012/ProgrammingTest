using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Domain.Entities
{
    public class DateAchievement
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalGoalsCompleted { get; set; }
        public double TotalGoalsSet { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
