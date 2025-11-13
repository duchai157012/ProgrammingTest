using ProgrammingTest.Domain.Entities;
using AutoMapper;
using ProgrammingTest.Application.DTOs.BodyRecord;

namespace ProgrammingTest.Application.Mappings
{
    public class BodyRecordProfile : Profile
    {
        public BodyRecordProfile()
        {
            CreateMap<BodyRecord, BodyRecordDTO>();
            CreateMap<BodyRecordDTO, BodyRecord>();
        }
    }
}
