using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_FD_Crew.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please input a first name")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted first name")]
        [StringLength(51, ErrorMessage = "First name must be between 1 and 51 characters long.")] 
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please input a last name")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted last name")]
        [StringLength(51, ErrorMessage = "Last name must be between 1 and 51 characters long.")]
        public String LastName { get; set; }


        [Required(ErrorMessage = "Please input an address")]
        [StringLength(51, 
            ErrorMessage = "Address must be between 1 and 51 characters long.")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Please input a city")]
        [RegularExpression("^([A-Z][a-z]+([ ]?[a-z]?['-]?[A-Z][a-z]+)*)$",
            ErrorMessage = "Please input a valid, properly formatted city name")]
        [StringLength(51, 
            ErrorMessage = "Address must be between 1 and 51 characters long.")]
        public String City { get; set; }

        [Required(ErrorMessage = "Please Input a state or province")]
        [StringLength(51, 
            ErrorMessage = "State must be between 1 and 51 characters long.")]
        public String StateProvince { get; set; }
        
        [Required(ErrorMessage = "Please input a postal code")]
        [StringLength(51, 
            ErrorMessage = "Postal code must be between 1 and 21 characters long.")]
        public String PostalCode { get; set; }


        public String CountryId { get; set; }
        public Country Country { get; set; }


        [Required(ErrorMessage = "Please Input a state or province")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please input a valid email address.")]
        [Remote("CheckEmail", "Validation")]
        public String? Email { get; set; }


        [RegularExpression("(\\+?( |-|\\.)?\\d{1,2}( |-|\\.)?)?(\\(?\\d{3}\\)?|\\d{3})( |-|\\.)?(\\d{3}( |-|\\.)?\\d{4})",
            ErrorMessage = "Please input a valid, properly formatted phone number including area code"),]
        public String? Phone { get; set; }

        public ICollection<Registration> Registrations { get; set; }


    }
}
