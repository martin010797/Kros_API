using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api_Firma.Models
{
    [Table("Structure")]
    public partial class Structure
    {
        public Structure()
        {
            BelongsTos = new HashSet<BelongsTo>();
            InverseUpperStructure = new HashSet<Structure>();
        }

        [Key]
        [Column("structureCode")]
        public int StructureCode { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("bossID")]
        public int BossId { get; set; }
        [Column("upperStructureID")]
        public int? UpperStructureId { get; set; }

        [ForeignKey(nameof(BossId))]
        [InverseProperty(nameof(Employee.Structures))]
        public virtual Employee Boss { get; set; }
        [ForeignKey(nameof(UpperStructureId))]
        [InverseProperty(nameof(Structure.InverseUpperStructure))]
        public virtual Structure UpperStructure { get; set; }
        [InverseProperty(nameof(BelongsTo.Structure))]
        public virtual ICollection<BelongsTo> BelongsTos { get; set; }
        [InverseProperty(nameof(Structure.UpperStructure))]
        public virtual ICollection<Structure> InverseUpperStructure { get; set; }
    }
}
