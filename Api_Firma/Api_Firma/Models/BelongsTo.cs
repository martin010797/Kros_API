using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api_Firma.Models
{
    [Table("BelongsTo")]
    public partial class BelongsTo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("employeeID")]
        public int EmployeeId { get; set; }
        [Column("structureID")]
        public int StructureId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty("BelongsTos")]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(StructureId))]
        [InverseProperty("BelongsTos")]
        public virtual Structure Structure { get; set; }
    }
}
