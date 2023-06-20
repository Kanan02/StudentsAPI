using Core.Models;

namespace Application.Queries.StudentQueries.GetAllStudents
{
    public class GetAllStudentsResponse
    {
        public FilteredDataResult<StudentResponse> Response { get; set; }
    }
}
