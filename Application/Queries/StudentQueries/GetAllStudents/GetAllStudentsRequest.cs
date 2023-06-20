using Core.Models;

namespace Application.Queries.StudentQueries.GetAllStudents
{
    public class GetAllStudentsRequest
    {
        public StudentFilterParameters FilterParameters { get; set; }
        public PagingParameters PagingParameters { get; set; }
    }
}
