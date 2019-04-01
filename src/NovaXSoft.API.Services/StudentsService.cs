using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NovaXSoft.API.DataAccess.Abstraction;
using NovaXSoft.API.DataAccess.Abstraction.Repository;
using NovaXSoft.API.Domain.DTOs.Student;
using NovaXSoft.API.Domain.Entities;
using NovaXSoft.API.Services.Abstraction;

namespace NovaXSoft.API.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly IMapper mapper;

        public StudentsService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.mapper = mapper;
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            using (IUnitOfWork uow = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                var studentRepository = uow.GetRepository<IStudentRepository>();

                var student = await studentRepository.GetByIdAsync(id);

                return this.mapper.Map<StudentDTO>(student);
            }
        }

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            using (IUnitOfWork uow = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                var studentRepository = uow.GetRepository<IStudentRepository>();

                var students = await studentRepository.GetAllAsync();

                return this.mapper.Map<List<StudentDTO>>(students);
            }
        }

        public async Task DeleteStudent(int id)
        {
            using (IUnitOfWork uow = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                var studentRepository = uow.GetRepository<IStudentRepository>();

                var student = await studentRepository.GetByIdAsync(id);

                if (student != null)
                {
                    studentRepository.Remove(student);
                    await uow.SaveChangesAsync();
                }
            }
        }

        public async Task<int> CreateStudent(StudentDTO student)
        {
            using (IUnitOfWork uow = this.unitOfWorkFactory.CreateUnitOfWork())
            {
                var studentRepository = uow.GetRepository<IStudentRepository>();

                var newStudent = this.mapper.Map<Student>(student);

                studentRepository.Add(newStudent);
                await uow.SaveChangesAsync();

                return newStudent.Id;
            }
        }
    }
}
