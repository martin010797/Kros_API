using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class StructureBasic
    {
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
    }
}
