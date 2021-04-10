using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GBCSporting2021_FD_Crew.Models
{
    internal class SeedIncidents : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> entity)
        {
            entity.HasData(IncidentValues());
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