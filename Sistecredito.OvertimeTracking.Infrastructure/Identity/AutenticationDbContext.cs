using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistecredito.OvertimeTracking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Identity
{
    public class AutenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AutenticationDbContext(DbContextOptions<AutenticationDbContext> options)
         : base(options)
        {
        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<ApplicationRole>? ApplicationRoles { get; set; }
    }
}
