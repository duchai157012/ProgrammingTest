using ProgrammingTest.Domain.Entities;
using AutoMapper;
using ProgrammingTest.Application.DTOs.Meal;

namespace ProgrammingTest.Application.Mappings
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<Meal, MealDTO>();
            CreateMap<MealDTO, Meal>();
        }
    }
}
