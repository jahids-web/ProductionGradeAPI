using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentStatic.GetAllStudent());
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        [HttpPost]
        public IActionResult Insert(Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string email, Student student)
        {
            return Ok(StudentStatic.UpdateStudent(email, student));
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }
    }

    public static class StudentStatic
    {
        private static List<Student> AllStudent { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            AllStudent.Add(student);
            return student;
        }
        public static List<Student> GetAllStudent()
        {
            return AllStudent;
        }
        public static Student GetAStudent(string Email)
        {
            return AllStudent.FirstOrDefault(x => x.Email == Email);
        }

        public static Student UpdateStudent(string email, Student student)
        {
            Student result = new Student();
            foreach (var aStudent in AllStudent)
            {
                if (email == aStudent.Email)
                {
                    aStudent.Email = student.Email;
                    return aStudent;
                }
            }
            return result;
        }

        public static Student DeleteStudent(string email)
        {
            var student = AllStudent.FirstOrDefault(x => x.Email == email);
            AllStudent = AllStudent.Where(x => x.Email != student.Email).ToList();
            return student;
        }


    }
}
