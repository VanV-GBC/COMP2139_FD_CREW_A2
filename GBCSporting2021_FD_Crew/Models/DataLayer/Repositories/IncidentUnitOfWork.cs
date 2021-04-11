using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_FD_Crew.Models 
{ 
    public class IncidentUnitOfWork : IIncidentUnitOfWork
    {
        SportsProContext context { get; set; }
        public IncidentUnitOfWork(SportsProContext contx) => context = contx;


        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<Technician> technicianData;
        public Repository<Technician> Technicians
        {
            get
            {
                if (technicianData == null)
                    technicianData = new Repository<Technician>(context);
                return technicianData;
            }
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<Incident> incidentData;
        public Repository<Incident> Incidents
        {
            get
            {
                if (incidentData == null)
                    incidentData = new Repository<Incident>(context);
                return incidentData;
            }
        }
    }
}
