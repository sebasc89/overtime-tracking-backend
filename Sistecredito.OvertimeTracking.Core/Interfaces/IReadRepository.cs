using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Core.Interfaces
{
    public interface IReadRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> FindByIdAsync(object id);
    }
}
