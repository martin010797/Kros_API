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
    public class EmployeesController : ControllerBase
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
                if (result == null)
                {
                    return NotFound("Employee with this ID doesnt exist");
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmployeeBasic>> UpdateEmployee(int id, EmployeeBasic employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var updatedEmployee = await employeeRepository.GetEmployee(id);

                if (updatedEmployee == null)
                {
                    return NotFound("Employee with this ID doesnt exist");
                }

                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deletedEmployee = await employeeRepository.GetEmployee(id);

                if (deletedEmployee == null)
                {
                    return NotFound("Employee with this ID doesnt exist");
                }

                await employeeRepository.DeleteEmployee(id);
                return Ok($"Employee with ID {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting employee");
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
