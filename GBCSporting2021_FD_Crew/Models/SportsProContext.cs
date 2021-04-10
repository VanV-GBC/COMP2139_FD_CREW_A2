using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GBCSporting2021_FD_Crew.Models
{
    public class SportsProContext : DbContext
    {

        public SportsProContext(DbContextOptions<SportsProContext> options) : base(options)
        {

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Registration>()
                .HasKey(bc => new { bc.ProductId, bc.CustomerId });
            modelBuilder.Entity<Registration>()
                .HasOne(p => p.Product)
                .WithMany(c => c.Registrations)
                .HasForeignKey(cu => cu.CustomerId);
            modelBuilder.Entity<Registration>()
                .HasOne(c => c.Customer)
                .WithMany(pr => pr.Registrations)
                .HasForeignKey(bc => bc.ProductId);

            modelBuilder.ApplyConfiguration(new SeedCountries());
            modelBuilder.ApplyConfiguration(new SeedTechnicians());
            modelBuilder.ApplyConfiguration(new SeedCustomers());
            modelBuilder.ApplyConfiguration(new SeedProducts());
            modelBuilder.ApplyConfiguration(new SeedIncidents());

        }

    }
}