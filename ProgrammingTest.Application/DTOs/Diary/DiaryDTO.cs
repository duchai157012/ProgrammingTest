using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTest.Application.DTOs.Diary
{
    public class DiaryDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Thoughts { get; set; }
        public Guid UserId { get; set; }
    }
}
