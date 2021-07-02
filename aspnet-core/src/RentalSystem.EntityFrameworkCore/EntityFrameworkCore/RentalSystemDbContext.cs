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
        public DbSet<Miscellaneous> Miscellaneous { get; set; }
        public DbSet<FacilityBooking> FacilityBookings { get; set; }
        public DbSet<ClientBooking> ClientBookings { get; set; }
        public DbSet<MiscellaneousBooking> MiscellaneousBookings { get; set; }

        public RentalSystemDbContext(DbContextOptions<RentalSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Client>()
                .HasIndex(u => u.Email).IsUnique();

            builder.Entity<Facility>()
                .HasIndex(u => u.Name).IsUnique();

            builder.Entity<Client>(
                o => o.OwnsOne(o => o.Address)
            );

            builder.Entity<FacilityBooking>()
                .HasKey(cs => new { cs.FacilityId, cs.BookingId });

            builder.Entity<FacilityBooking>()
                .HasOne(sl => sl.Facility)
                .WithMany(s => s.FacilityBookings)
                .HasForeignKey(sl => sl.FacilityId);

            builder.Entity<FacilityBooking>()
                .HasOne(sl => sl.Booking)
                .WithMany(l => l.FacilityBookings)
                .HasForeignKey(sl => sl.BookingId);

            builder.Entity<ClientBooking>()
                .HasKey(cs => new { cs.ClientId, cs.BookingId });

            builder.Entity<ClientBooking>()
                .HasOne(sl => sl.Client)
                .WithMany(s => s.ClientBookings)
                .HasForeignKey(sl => sl.ClientId);

            builder.Entity<MiscellaneousBooking>()
               .HasKey(cs => new { cs.MiscellaneousId, cs.BookingId });

            builder.Entity<MiscellaneousBooking>()
                .HasOne(sl => sl.Miscellaneous)
                .WithMany(s => s.MiscellaneousBookings)
                .HasForeignKey(sl => sl.MiscellaneousId);

            builder.Entity<MiscellaneousBooking>()
                .HasOne(sl => sl.Booking)
                .WithMany(l => l.MiscellaneousBookings)
                .HasForeignKey(sl => sl.BookingId);
        }
    }
}
