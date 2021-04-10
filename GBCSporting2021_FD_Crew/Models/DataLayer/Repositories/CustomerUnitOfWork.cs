using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_FD_Crew.Models  
{
    public class CustomerUnitOfWork : ICustomertUnitOfWork
    {

        private SportsProContext context { get; set; }
        public CustomerUnitOfWork(SportsProContext contx) => context = contx;
        private Repository<Customer> customerData;
        private Repository<Country> countryData;

        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }
    } 
}
