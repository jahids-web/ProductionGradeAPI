using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get all Student");
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok("get "+ code + "department data");
        }

        [HttpPost]
        public IActionResult Insert(string code)
        {
            return Ok("Insert New Department");
        }

        [HttpPut("{code}")]
        public IActionResult Updat(string code)
        {
            return Ok("Update " + code + "deparmet data");
        }

        [HttpGet("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok("Delete " + code + "deparmet data");
        }

<<<<<<< HEAD
    }

    public static class DepartmentStatic
    {
        private static List<Department> AllDepartment { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            AllDepartment.Add(department);
            return department;
        }
        public static List<Department> GetAllDepartmant()
        {
            return AllDepartment;
        }
        public static Department GetDepartment (string code)
        {
            return AllDepartment.FirstOrDefault(x => x.Code == code);
        }

        public static Department UpdateDepartment(string code, Department department)
        {
          
            foreach (var aDepartent in AllDepartment)
            {
                if(code == aDepartent.Code)
                {
                    aDepartent.Name = department.Name;
                }
            }
            return department;
        }

        public static Department DeleteDepartment(string code)
        {
            var department = AllDepartment.FirstOrDefault(x => x.Code == code);
            AllDepartment = AllDepartment.FirstOrDefault(x => x.Code != department.Code).ToList();
            return department;
        }
        
=======
>>>>>>> 560b18ac72887680d92b3e18f5277237677d2d19
    }
}
