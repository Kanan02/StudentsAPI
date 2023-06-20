namespace Application.Queries.StudentQueries
{
    public class StudentFilterParameters
    {
        public List<string> Ids { get; set; } = new();
        public string FullName { get; set; } = "";
    }
}
