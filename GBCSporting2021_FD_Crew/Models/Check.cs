using System.Linq;

namespace GBCSporting2021_FD_Crew.Models
{
    public class Check
    {
        public static string EmailExists(Repository<Customer> cust, string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = cust.Get(email);
                if (customer != null)
                    msg = $"Email address {email} already in use.";
            }
            return msg;
        }
    }
}
