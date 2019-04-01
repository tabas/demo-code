using NovaXSoft.API.Domain.DTOs.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovaXSoft.API.Services.Abstraction
{
    public interface IStudentsService
    {
        Task<List<StudentDTO>> GetAllStudents();

        Task<StudentDTO> GetStudentById(int id);

        Task DeleteStudent(int id);

        Task<int> CreateStudent(StudentDTO student);
    }
}
