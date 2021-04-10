using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GBCSporting2021_FD_Crew.Models
{
    internal class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(ProductValues());
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
    }
}