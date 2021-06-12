using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RentalSystem.EntityFrameworkCore
{
    public static class RentalSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RentalSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RentalSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
