using Infrastructure.Configurations.Queries;
using DataAccess.Repositoies.StudentRepository;
using Microsoft.EntityFrameworkCore;
using Core.Exceptions;

namespace Application.Queries.StudentQueries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IQueryHandler<GetStudentByIdQuery, GetStudentByIdResponse>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByIdQueryHandler(IStudentRepository studentResultRepository)
        {
            _studentRepository = studentResultRepository;
        }


        public async Task<GetStudentByIdResponse> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {

            var data =await _studentRepository.FindBy(s=>s.Id==query.Request.Id).FirstOrDefaultAsync() ?? throw new RecordNotFoundException("Requested student not found");
            
            return new GetStudentByIdResponse()
            {
                Response = data
            };
        }
    }
}
