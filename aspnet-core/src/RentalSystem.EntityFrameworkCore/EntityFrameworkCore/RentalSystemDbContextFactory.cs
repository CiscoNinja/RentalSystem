using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RentalSystem.Configuration;
using RentalSystem.Web;

namespace RentalSystem.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RentalSystemDbContextFactory : IDesignTimeDbContextFactory<RentalSystemDbContext>
    {
        public RentalSystemDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RentalSystemDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RentalSystemDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RentalSystemConsts.ConnectionStringName));

            return new RentalSystemDbContext(builder.Options);
        }
    }
}
