using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Application.DTOs.DateAchievement;
using AutoMapper;

namespace ProgrammingTest.Application.Mappings
{
    public class DateAchievementProfile : Profile
    {
        public DateAchievementProfile()
        {
            CreateMap<DateAchievement, DateAchievementDTO>();
            CreateMap<DateAchievementDTO, DateAchievement>();
        }
    }
}
