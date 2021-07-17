using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class EmployeeBasic
    {
        public int EmployeeId { get; set; }
        public string Degree { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
