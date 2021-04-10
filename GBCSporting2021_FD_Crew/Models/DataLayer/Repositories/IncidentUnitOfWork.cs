namespace GBCSporting2021_FD_Crew.Models 
{ 
    public class IncidentUnitOfWork : IIncidentUnitOfWork
    {
        SportsProContext context { get; set; }
        public IncidentUnitOfWork(SportsProContext ctx) => context = ctx;

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

        public void DeleteIncidents(Incident incident)
        {
            var currentIncidents = Incidents.List(new QueryOptions<Incident>
            {
                Where = i => i.IncidentId == incident.IncidentId
            });
            foreach (Incident i in currentIncidents)
            {
                Incidents.Delete(i);
            }
        }

        public void AddNewIncidents(Incident incident, int[] incidentids)
        {
            foreach(int id in incidentids) 
            {
                Incident i = 
                    new Incident {IncidentId = id, CustomerId =  }
            }
        }



    }
}
