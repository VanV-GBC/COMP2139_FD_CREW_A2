using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_FD_Crew.Models
{
    public class Registration
    {

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }


        public int? ProductId { get; set; }
        public Product Product { get; set; }

    }
}
