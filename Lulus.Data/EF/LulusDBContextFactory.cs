using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lulus.Data.EF
{
    public class LulusDBContextFactory : IDesignTimeDbContextFactory<LulusDBContext>
    {
        public LulusDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LulusDatabase");

            var optionBuilder = new DbContextOptionsBuilder<LulusDBContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new LulusDBContext(optionBuilder.Options);
        }
    }
}
