using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest_API_CRUD.EmployeeData;
using Rest_API_CRUD.Models;

namespace Rest_API_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private IEmployee _employee;
        public EmpController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employee.GetEmployees());
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employee.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id:{id} was not found");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employee.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employees = _employee.GetEmployee(id);
            if(employees != null)
            {
                _employee.DeleteEmployee(employees);
                return Ok();
                 
            }
            return NotFound($"Employee with Id:{id} was not found");
        }
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id,Employee employee)
        {
             var existing_employee=_employee.GetEmployee(id);
            if (existing_employee != null)
            {
                employee.Id = existing_employee.Id;
                _employee.EditEmployee(employee);
                 

            }
            return Ok(employee);
        }

    }
}
