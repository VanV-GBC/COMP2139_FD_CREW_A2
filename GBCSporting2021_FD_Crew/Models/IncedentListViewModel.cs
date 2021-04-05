using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_FD_Crew.Models
{
    public class IncedentListViewModel
    {
        private List<Incident> incidents {get; set;}
        private string filter;
        public List<Incident> Incidents {get => incidents; set => incidents = value;}
        public string Filter {get => filter; set => filter = value;}

    }
}
