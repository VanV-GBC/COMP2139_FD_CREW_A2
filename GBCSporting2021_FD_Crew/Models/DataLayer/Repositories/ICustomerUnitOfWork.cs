namespace GBCSporting2021_FD_Crew.Models
{

    public interface ICustomerUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Country> Countries { get; }



        void ClearCountries(Country country);

        SportsProContext GetContext();
        //void UpdateCustomer(Customer customer, int id);
        //void DeleteCustomer(Customer customer, int id);
        //void CustomerList(QueryOptions<Customer> customer);
        //void AddCountries(Customer customer, string[] countryids);

    }
}