using Sistecredito.OvertimeTracking.Core.Entities;
using Sistecredito.OvertimeTracking.Core.Interfaces.Repositories;
using Sistecredito.OvertimeTracking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Repositories.Core
{
    public class ApprovalStatusRepository : BaseRepository<ApprovalStatus>, IApprovalStatusRepository
    {
        public ApplicationDbContext Context
        {
            get
            {
                return (ApplicationDbContext)_context;
            }
        }

        public ApprovalStatusRepository(ApplicationDbContext database)
            : base(database)
        {
        }
    }
}
