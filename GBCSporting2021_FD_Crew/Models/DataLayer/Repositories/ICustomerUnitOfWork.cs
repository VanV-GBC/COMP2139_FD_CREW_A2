namespace GBCSporting2021_FD_Crew.Models
{

    public interface ICustomertUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Country> Countries { get; }
        Repository<Product> Products { get; }
        Repository<Incident> Incidents { get; }

        void DeleteCustomers(Customer customer);
    }
}