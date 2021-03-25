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

            modelBuilder.Entity<Country>().HasData(CountryValues());
            modelBuilder.Entity<Technician>().HasData(TechnicianValues());
            modelBuilder.Entity<Customer>().HasData(CustomerValues());
            modelBuilder.Entity<Product>().HasData(ProductValues());
            modelBuilder.Entity<Incident>().HasData(IncidentValues());

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
        }

        private static List<Country> CountryValues()
        {
            var itemvalue = new List<Country>();
            using (StreamReader r = new StreamReader(@"Seed_Data/countries.json"))
            {
                string json = r.ReadToEnd();
                itemvalue = JsonConvert.DeserializeObject<List<Country>>(json);
            }
            return itemvalue;
        }

        private static List<Customer> CustomerValues()
        {
            var itemvalue = new List<Customer>();
            using (StreamReader r = new StreamReader(@"Seed_Data/customers.json"))
            {
                string json = r.ReadToEnd();
                itemvalue = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
            return itemvalue;
        }

        private static List<Product> ProductValues()
        {
            var itemvalue = new List<Product>();
            using (StreamReader r = new StreamReader(@"Seed_Data/products.json"))
            {
                string json = r.ReadToEnd();
                itemvalue = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return itemvalue;
        }


        private static List<Technician> TechnicianValues()
        {
            var itemvalue = new List<Technician>();
            using (StreamReader r = new StreamReader(@"Seed_Data/technicians.json"))
            {
                string json = r.ReadToEnd();
                itemvalue = JsonConvert.DeserializeObject<List<Technician>>(json);
            }
            return itemvalue;
        }

        private static List<Incident> IncidentValues()
        {
            var itemvalue = new List<Incident>();
            using (StreamReader r = new StreamReader(@"Seed_Data/incidents.json"))
            {
                string json = r.ReadToEnd();
                itemvalue = JsonConvert.DeserializeObject<List<Incident>>(json);
            }
            return itemvalue;
        }





    }
}