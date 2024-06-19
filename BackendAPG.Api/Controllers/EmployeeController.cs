using BackendApg.Business;
using BackendApg.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _employeeBusiness.GetAllEmployees());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Employee>>> Get(string name)
        {
            return Ok(await _employeeBusiness.GetEmployeesByName(name));
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _employeeBusiness.AddEmployee(employee);
            return Ok("Employee added sucessfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(string id)
        {
            await _employeeBusiness.DeleteEmployee(id);
            return Ok("Employee deleted sucessfully");
        }
    }
}
