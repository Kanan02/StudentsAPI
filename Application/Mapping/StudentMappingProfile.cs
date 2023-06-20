using Application.Queries.StudentQueries;
using AutoMapper;
using Domain.Entities;
namespace Application.Mapping
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
          //  CreateMap<CreateStudentRequest, Student>();
            CreateMap<Student, StudentResponse>();
        }
    }
}
