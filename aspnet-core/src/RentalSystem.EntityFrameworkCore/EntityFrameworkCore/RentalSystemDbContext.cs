using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RentalSystem.Authorization.Roles;
using RentalSystem.Authorization.Users;
using RentalSystem.MultiTenancy;
using RentalSystem.Entities;

namespace RentalSystem.EntityFrameworkCore
{
    public class RentalSystemDbContext : AbpZeroDbContext<Tenant, Role, User, RentalSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        public RentalSystemDbContext(DbContextOptions<RentalSystemDbContext> options)
            : base(options)
        {
        }
    }
}
