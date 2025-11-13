using ProgrammingTest.Domain.Entities;
using AutoMapper;
using ProgrammingTest.Application.DTOs.Exercise;

namespace ProgrammingTest.Application.Mappings
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseDTO, Exercise>();
        }
    }
}
