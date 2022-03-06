﻿using BLL.Services;
using DLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        public readonly  IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetA(string email)
        {
            return Ok(await _studentService.GetAAsync(email));
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Student student)
        {
            return Ok(await _studentService.InsertAsync(student));
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> Update(string email, Student student)
        {
            return Ok(await _studentService.UpdateAsync(email,student));
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            return Ok(await _studentService.DeleteAsync(email));
        }
    }

   
}
