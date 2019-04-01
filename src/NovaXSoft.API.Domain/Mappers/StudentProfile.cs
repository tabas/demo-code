using AutoMapper;
using NovaXSoft.API.Domain.DTOs.Student;
using NovaXSoft.API.Domain.Entities;

namespace NovaXSoft.API.Domain.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, Student>()
                .ForMember(s => s.Id, opt => opt.Ignore());
        }
    }
}
