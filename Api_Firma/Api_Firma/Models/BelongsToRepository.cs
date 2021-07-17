using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public class BelongsToRepository : IBelongsToRepository
    {
        private readonly AppDbContext appDbContext;
        public BelongsToRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<BelongsTo> AddBelonging(BelongsTo belongsTo)
        {
            var result = await appDbContext.BelongsTos.AddAsync(belongsTo);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteBelonging(int ID)
        {
            var result = await appDbContext.BelongsTos
                .FirstOrDefaultAsync(b => b.Id == ID);
            if (result != null)
            {
                appDbContext.BelongsTos.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<BelongsTo> GetBelongsTo(int ID)
        {
            return await appDbContext.BelongsTos
                .FirstOrDefaultAsync(b => b.Id == ID);
        }

        public async Task<IEnumerable<BelongsTo>> GetBelongsTos()
        {
            return await appDbContext.BelongsTos.ToListAsync();
        }

        public async Task<BelongsTo> UpdateBelonging(BelongsTo belongsTo)
        {
            var result = await appDbContext.BelongsTos
                .FirstOrDefaultAsync(b => b.Id == belongsTo.Id);
            if (result != null)
            {
                result.EmployeeId = belongsTo.EmployeeId;
                result.StructureId = belongsTo.StructureId;

                await appDbContext.SaveChangesAsync();
            }
            return null;
        }
    }
}
