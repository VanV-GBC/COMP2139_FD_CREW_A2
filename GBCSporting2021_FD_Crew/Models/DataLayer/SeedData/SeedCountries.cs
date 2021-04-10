using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GBCSporting2021_FD_Crew.Models
{
    internal class SeedCountries : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(CountryValues());
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
    }
}