using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Queries.StudentQueries
{
    public class StudentResponse
    {
        public string Id { get; set; }
        
        public string FullName { get; set; } = "";
        
        public DateTime DateOfBirth { get; set; }

        public double Average { get; set; } = 0;


    }
}
