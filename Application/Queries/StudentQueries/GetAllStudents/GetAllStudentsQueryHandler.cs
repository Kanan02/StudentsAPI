using AutoMapper;
using Core.Models;
using Infrastructure.Configurations.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;
using Domain.Entities;
using DataAccess.Repositoies.StudentRepository;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.StudentQueries.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, GetAllStudentsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IMapper mapper, IStudentRepository studentResultRepository)
        {
            _mapper = mapper;
            _studentRepository = studentResultRepository;
        }


        public async Task<GetAllStudentsResponse> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
        {
            StudentFilterParameters? filterParameters = query.Request.FilterParameters;
            Expression<Func<Student, bool>> filterPredicate = c => true;
           
            if (filterParameters != null)
            {
                bool isIdsExist = filterParameters.Ids != null && filterParameters.Ids.Any();
                bool isNameExist = !String.IsNullOrEmpty(filterParameters.FullName);

                filterPredicate = c =>
                    (!isIdsExist || filterParameters.Ids.Contains(c.Id)) &&
                     (!isNameExist || c.FullName.Contains( filterParameters.FullName));
            }

            var data = _studentRepository.FindBy(filterPredicate);

            data = data.FindPaged(query.Request.PagingParameters);

            var list = await data.ToListAsync();
            List<StudentResponse> result = _mapper.Map<List<Student>, List<StudentResponse>>(list);

            return new GetAllStudentsResponse()
            {
                Response = new FilteredDataResult<StudentResponse>()
                {
                    Items = result,
                }
            };
        }
    }
}
