using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_FD_Crew.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select a customer")]
        public int CustomerId { set; get; }
        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "Please select a product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int? TechnicianId { get; set; }
        public virtual Technician Technician { get; set; }

        [Required(ErrorMessage = "Please input an incident title")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Please input an incident description")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Please select incident open date")]
        public DateTime dateOpened { get; set; }

        public DateTime? dateClosed { get; set; }
    }
}