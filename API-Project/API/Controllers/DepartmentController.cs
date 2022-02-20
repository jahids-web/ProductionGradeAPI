using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
