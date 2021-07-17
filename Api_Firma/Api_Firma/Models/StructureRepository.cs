﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class StructureRepository : IStructureRepository
    {
        private readonly AppDbContext appDbContext;

        public StructureRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Structure> AddStructure(Structure structure)
        {
            var result = await appDbContext.Structures.AddAsync(structure);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStructure(int structureID)
        {
            //ak existuju  vstrukture nejaky zamestnanci tak mazat aj z belongsto tabulky

            var result = await appDbContext.Structures
                .FirstOrDefaultAsync(s => s.StructureCode == structureID);
            if (result != null)
            {
                appDbContext.Structures.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Structure> GetStructure(int structureID)
        {
            return await appDbContext.Structures
                .FirstOrDefaultAsync(s => s.StructureCode == structureID);
        }

        public async Task<IEnumerable<StructureBasic>> GetStructures()
        {
            //return await appDbContext.Structures.ToListAsync();
            return await appDbContext.Structures
                .Select(x => StructureToBasic(x))
                .ToListAsync();
        }

        private static StructureBasic StructureToBasic(Structure structure) =>
            new StructureBasic
            {
                StructureCode = structure.StructureCode,
                Name = structure.Name,
                Type = structure.Type,
                BossId = structure.BossId,
                UpperStructureId = structure.UpperStructureId
            };

        public async Task<Structure> UpdateStructure(Structure structure)
        {
            var result = await appDbContext.Structures
                .FirstOrDefaultAsync(s => s.StructureCode == structure.StructureCode);
            if (result != null)
            {
                result.Name = structure.Name;
                result.Type = structure.Type;
                result.BossId = structure.BossId;
                result.UpperStructureId = structure.UpperStructureId;

                await appDbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}