namespace GBCSporting2021_FD_Crew.Models
{

    public interface ICustomertUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Country> Countries { get; }

/*        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer, int id);
        void DeleteCustomer(Customer customer);*/
        

    }
}