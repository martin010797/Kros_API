using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api_Firma.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        public Employee()
        {
            BelongsTos = new HashSet<BelongsTo>();
            Structures = new HashSet<Structure>();
        }

        [Key]
        [Column("employeeID")]
        public int EmployeeId { get; set; }
        [Column("degree")]
        [StringLength(10)]
        public string Degree { get; set; }
        [Required]
        [Column("name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Column("surname")]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [Column("cellPhone")]
        [StringLength(20)]
        public string CellPhone { get; set; }
        [Required]
        [Column("email")]
        [StringLength(20)]
        public string Email { get; set; }

        [InverseProperty(nameof(BelongsTo.Employee))]
        public virtual ICollection<BelongsTo> BelongsTos { get; set; }
        [InverseProperty(nameof(Structure.Boss))]
        public virtual ICollection<Structure> Structures { get; set; }
    }
}
