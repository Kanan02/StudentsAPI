using Infrastructure.Configurations.Queries;

namespace Application.Queries.StudentQueries.GetAllStudents
{
    public class GetAllStudentsQuery : IQuery<GetAllStudentsResponse>
    {
        public GetAllStudentsQuery(GetAllStudentsRequest request)
        {
            Request = request;
        }

        public GetAllStudentsRequest Request { get; set; }
    }
}
