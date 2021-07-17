using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Firma.Models
{
    public interface IBelongsToRepository
    {
        Task<IEnumerable<BelongsTo>> GetBelongsTos();
        Task<BelongsTo> GetBelongsTo(int ID);
        Task<BelongsTo> AddBelonging(BelongsTo belongsTo);
        Task<BelongsTo> UpdateBelonging(BelongsTo belongsTo);
        Task DeleteBelonging(int ID);
    }
}
