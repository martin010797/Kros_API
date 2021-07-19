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
        public async Task<BelongsTo> AddBelonging(BelongsToBasic belongsTo)
        {
            /*var result = await appDbContext.BelongsTos.AddAsync(belongsTo);
            await appDbContext.SaveChangesAsync();
            return result.Entity;*/

            var newBelongsTo = new BelongsTo
            {
                Id = belongsTo.Id,
                EmployeeId = belongsTo.EmployeeId,
                StructureId = belongsTo.StructureId
            };
            var result = await appDbContext.BelongsTos.AddAsync(newBelongsTo);
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

        public async Task<BelongsToBasic> GetBelongsTo(int ID)
        {
            var result = await appDbContext.BelongsTos
                .FirstOrDefaultAsync(b => b.Id == ID);
            if(result == null)
            {
                return null;
            }
            return BelongsToToBasic(result);
        }

        public async Task<IEnumerable<BelongsToBasic>> GetBelongsTos()
        {
            return await appDbContext.BelongsTos
                .Select(x => BelongsToToBasic(x))
                .ToListAsync();
        }

        public async Task<BelongsToBasic> UpdateBelonging(BelongsToBasic belongsTo)
        {
            var result = await appDbContext.BelongsTos
                .FirstOrDefaultAsync(b => b.Id == belongsTo.Id);
            if (result != null)
            {
                result.EmployeeId = belongsTo.EmployeeId;
                result.StructureId = belongsTo.StructureId;

                await appDbContext.SaveChangesAsync();

                return BelongsToToBasic(result);
            }
            return null;
        }

        private static BelongsToBasic BelongsToToBasic(BelongsTo belongsTo) =>
           new BelongsToBasic
           {
               Id = belongsTo.Id,
               EmployeeId = belongsTo.EmployeeId,
               StructureId = belongsTo.StructureId
           };
    }
}
