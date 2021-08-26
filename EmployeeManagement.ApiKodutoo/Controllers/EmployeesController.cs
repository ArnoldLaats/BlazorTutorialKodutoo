using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.ApiKodutoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
