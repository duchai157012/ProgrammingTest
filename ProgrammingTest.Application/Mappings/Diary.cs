using ProgrammingTest.Domain.Entities;
using AutoMapper;
using ProgrammingTest.Application.DTOs.Diary;

namespace ProgrammingTest.Application.Mappings
{
    public class DiaryProfile : Profile
    {
        public DiaryProfile()
        {
            CreateMap<Diary, DiaryDTO>();
            CreateMap<DiaryDTO, Diary>();
        }
    }
}
