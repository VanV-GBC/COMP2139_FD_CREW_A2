using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_FD_Crew.Models  
{
    public class CustomerUnitOfWork : ICustomerUnitOfWork
    {

        private SportsProContext context { get; set; }
        public CustomerUnitOfWork(SportsProContext contx) => context = contx;

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

        private Repository<Country> countryData;
        public Repository<Country> Countries
        {
            get
            {
                if (countryData == null)
                    countryData = new Repository<Country>(context);
                return countryData;
            }
        }

        public void ClearCountries(Country country) {
            var currentCountries = Countries.List(new QueryOptions<Country> { 
                Where = c => c.CountryId == country.CountryId
            });
            foreach(Country c in currentCountries)
            {
                Countries.Delete(c);
            }
        
        }

        public SportsProContext GetContext()
        {
            return context;
        }

    } 
}
