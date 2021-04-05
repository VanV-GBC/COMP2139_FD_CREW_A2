using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_FD_Crew.Models
{
    public class IncedentEditModel
    {
        private Incident incedent;
        private List<Customer> customers;
        private List<Product> products;
        private List<Technician> technicians;
        private string action;
        public Incident Incident {get => incedent; set => incedent = value;}
        public List<Customer> Customers { get => customers; set => customers = value; }
        public List<Product> Products { get => products; set => products = value; }
        public List<Technician> Technicians { get => technicians; set => technicians = value; }
        public string Action { get => action; set => action = value; }
    }
}
