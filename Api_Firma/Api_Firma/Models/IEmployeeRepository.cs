using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeBasic>> GetEmployees();
        Task<EmployeeBasic> GetEmployee(int employeeID);
        Task<Employee> AddEmployee(EmployeeBasic employee);
        Task<EmployeeBasic> UpdateEmployee(EmployeeBasic employee);
        Task DeleteEmployee(int employeeID);
    }
}
