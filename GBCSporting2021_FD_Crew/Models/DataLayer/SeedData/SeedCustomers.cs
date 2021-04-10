using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GBCSporting2021_FD_Crew.Models
{
    internal class SeedCustomers : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.HasData(CustomerValues());
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
    }
}
