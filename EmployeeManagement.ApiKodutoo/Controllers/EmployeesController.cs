using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EmployeeManagement.ApiKodutoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.ModelsKodutoo;

namespace EmployeeManagement.ApiKodutoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepistory)
        {
            this.employeeRepository = employeeRepistory;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCode.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if(result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCode.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return BadRequest();
                }

                var emp = employeeRepository.GetEmployeeByEmail(employee.Email);

                if(emp != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId}
                    ,createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCode.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
