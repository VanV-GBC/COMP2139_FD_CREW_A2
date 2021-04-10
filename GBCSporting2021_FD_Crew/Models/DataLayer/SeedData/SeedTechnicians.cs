using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GBCSporting2021_FD_Crew.Models
{
    internal class SeedTechnicians : IEntityTypeConfiguration<Technician>
    {
        public void Configure(EntityTypeBuilder<Technician> entity)
        {
            entity.HasData(TechnicianValues());
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
    }
}