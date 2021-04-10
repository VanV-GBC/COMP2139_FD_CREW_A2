namespace GBCSporting2021_FD_Crew.Models
{

    public interface ICustomertUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Country> Countries { get; }

        void DeleteCustomer(Customer customer);
    }
}