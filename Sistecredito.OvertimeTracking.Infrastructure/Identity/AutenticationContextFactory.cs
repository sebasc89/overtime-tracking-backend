using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Sistecredito.OvertimeTracking.Infrastructure.Identity
{
    public class AutenticationDbContextFactory : IDesignTimeDbContextFactory<AutenticationDbContext>
    {
        public AutenticationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AutenticationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AutenticationDbContext(optionsBuilder.Options);
        }
    }

}
