using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public interface IBelongsToRepository
    {
        Task<IEnumerable<BelongsToBasic>> GetBelongsTos();
        Task<BelongsToBasic> GetBelongsTo(int ID);
        Task<BelongsTo> AddBelonging(BelongsToBasic belongsTo);
        Task<BelongsToBasic> UpdateBelonging(BelongsToBasic belongsTo);
        Task DeleteBelonging(int ID);
    }
}
