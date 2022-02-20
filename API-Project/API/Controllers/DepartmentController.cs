﻿using API.Models;
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
            return Ok(DepartmentStatic.GetAllDepartmant());
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DepartmentStatic.GetDepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DepartmentStatic.InsertDepartment(department));
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
        

    }
}
