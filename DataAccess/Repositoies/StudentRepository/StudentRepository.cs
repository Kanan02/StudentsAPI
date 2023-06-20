using Data;
using Domain.Entities;

namespace DataAccess.Repositoies.StudentRepository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
