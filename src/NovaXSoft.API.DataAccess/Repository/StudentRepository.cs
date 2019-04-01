using NovaXSoft.API.DataAccess.Abstraction.Repository;
using NovaXSoft.API.Domain.Entities;

namespace NovaXSoft.API.DataAccess.Repository
{
    public class StudentRepository : EntityFrameworkRepository<Student, int>, IStudentRepository
    {
    }
}
