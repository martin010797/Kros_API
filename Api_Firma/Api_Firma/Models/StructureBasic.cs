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
        public int StructureCode { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int BossId { get; set; }
        public int? UpperStructureId { get; set; }
    }
}
