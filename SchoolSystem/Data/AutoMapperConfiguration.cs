using AutoMapper;
using SchoolSystem.Dtos;
using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Degree, DegreeDto>().ReverseMap();
            CreateMap<DegreeDto, Degree>().ReverseMap();
        }
    }
}
