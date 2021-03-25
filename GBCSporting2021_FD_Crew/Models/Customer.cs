using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_FD_Crew.Models
{
    public class Customer
    {

        // will have to test all the regex validations

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please input a first name")]

        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted first name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please input a last name")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted last name")]
        public String LastName { get; set; }


        [Required(ErrorMessage = "Please input an address")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Please input a city")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted city name")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please Input a state or province")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted state or province name")]

        public String StateProvince { get; set; }
        
        [Required(ErrorMessage = "Please input a postal code")]
        public String PostalCode { get; set; }


        public String CountryId { get; set; }
        public Country Country { get; set; }
        
        
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage = "Please input a valid, properly formatted email address.")]
        public String? Email { get; set; }


        [RegularExpression("(\\+?( |-|\\.)?\\d{1,2}( |-|\\.)?)?(\\(?\\d{3}\\)?|\\d{3})( |-|\\.)?(\\d{3}( |-|\\.)?\\d{4})",
            ErrorMessage = "Please input a valid, properly formatted phone number including area code"),]
        public String? Phone { get; set; }

        public ICollection<Registration> Registrations { get; set; }


    }
}
