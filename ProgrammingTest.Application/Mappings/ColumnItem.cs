using ProgrammingTest.Domain.Entities;
using AutoMapper;
using ProgrammingTest.Application.DTOs.ColumnItem;

namespace ProgrammingTest.Application.Mappings
{
    public class ColumnItemProfile : Profile
    {
        public ColumnItemProfile()
        {
            CreateMap<ColumnItem, ColumnItemDTO>();
            CreateMap<ColumnItemDTO, ColumnItem>();
        }
    }
}
