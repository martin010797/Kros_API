using Api_Firma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeeBasic>> GetEmployee(int id)
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeBasic>> CreateEmployee(EmployeeBasic employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var newEmployee = await employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee),
                    new { id = newEmployee.EmployeeId }, EmployeeToBasic(newEmployee));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee");
            }
        }

        private static EmployeeBasic EmployeeToBasic(Employee employee) =>
            new EmployeeBasic
            {
                EmployeeId = employee.EmployeeId,
                Degree = employee.Degree,
                Name = employee.Name,
                Surname = employee.Surname,
                CellPhone = employee.CellPhone,
                Email = employee.Email
            };
    }
}
