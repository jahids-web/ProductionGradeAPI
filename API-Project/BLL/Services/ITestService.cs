using DLL.Models;
using DLL.UniteOfWork;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestService
    {
        Task InsertData();
    }
    public class TestService : ITestService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentRepository _studentRepository;

        public TestService(IStudentRepository studentRepository,IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
        }
        public async Task InsertData()
        {
            var department = new Department()
            {
                Code = "arts",
                Name = "art department"
            };
            var student = new Student()
            {
                Email = "art@gmail.com",
                Name= "Pint Art"
            };

            await _departmentRepository.CreateAsync(department);
            await _studentRepository.CreateAsync(student);




        }
    }
}
