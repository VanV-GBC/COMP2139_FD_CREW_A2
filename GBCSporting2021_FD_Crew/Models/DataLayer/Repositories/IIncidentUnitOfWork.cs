namespace GBCSporting2021_FD_Crew.Models 
{ 

    public interface IIncidentUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Technician> Technicians { get; }
        Repository<Product> Products { get; }
        Repository<Incident> Incidents { get; }

        void DeleteIncidents(Incident incident);
    }
}
