using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(EmployeeBasic employee)
        {
            var newEmployee = new Employee
            {
                EmployeeId = employee.EmployeeId,
                Degree = employee.Degree,
                Name = employee.Name,
                Surname = employee.Surname,
                CellPhone = employee.CellPhone,
                Email = employee.Email
            };

            var result = await appDbContext.Employees.AddAsync(newEmployee);
            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeID)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeID);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<EmployeeBasic> GetEmployee(int employeeID)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeID);

            if (result == null)
            {
                return null;
            }

            return EmployeeToBasic(result);
        }

        public async Task<IEnumerable<EmployeeBasic>> GetEmployees()
        {
            return await appDbContext.Employees
                .Select(x => EmployeeToBasic(x))
                .ToListAsync();
        }

        public async Task<EmployeeBasic> UpdateEmployee(EmployeeBasic employee)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.Degree = employee.Degree;
                result.Name = employee.Name;
                result.Surname = employee.Surname;
                result.CellPhone = employee.CellPhone;
                result.Email = employee.Email;

                await appDbContext.SaveChangesAsync();

                return EmployeeToBasic(result);
            }
            return null;
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
