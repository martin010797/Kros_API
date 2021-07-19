using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class BelongsToBasic
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("employeeID")]
        public int EmployeeId { get; set; }
        [Column("structureID")]
        public int StructureId { get; set; }
    }
}
