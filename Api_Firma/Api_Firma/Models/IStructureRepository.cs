using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public interface IStructureRepository
    {
        Task<IEnumerable<StructureBasic>> GetStructures();
        Task<Structure> GetStructure(int structureID);
        Task<Structure> AddStructure(Structure structure);
        Task<Structure> UpdateStructure(Structure structure);
        Task DeleteStructure(int structureID);
    }
}
