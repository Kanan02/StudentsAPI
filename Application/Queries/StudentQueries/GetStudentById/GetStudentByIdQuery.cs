using Infrastructure.Configurations.Queries;

namespace Application.Queries.StudentQueries.GetStudentById
{
    public class GetStudentByIdQuery : IQuery<GetStudentByIdResponse>
    {
        public GetStudentByIdQuery(GetStudentByIdRequest request)
        {
            Request = request;
        }

        public GetStudentByIdRequest Request { get; set; }
    }
}
