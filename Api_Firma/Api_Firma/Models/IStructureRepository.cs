using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public interface IStructureRepository
    {
        Task<IEnumerable<StructureBasic>> GetStructures();
        Task<StructureBasic> GetStructure(int structureID);
        Task<Structure> AddStructure(StructureBasic structure);
        Task<StructureBasic> UpdateStructure(StructureBasic structure);
        Task DeleteStructure(int structureID);
    }
}
