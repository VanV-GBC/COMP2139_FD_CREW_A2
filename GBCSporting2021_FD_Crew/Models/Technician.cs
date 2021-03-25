using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GBCSporting2021_FD_Crew.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please input a name")]
        public String Name { get; set; }


        [Required(ErrorMessage = "Please input a valid email address")]
        [RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
            ErrorMessage = "Please input a valid, properly formatted email address.")]
        public String Email { get; set; }


        [Required(ErrorMessage = "Please input a valid phone number")]
        [RegularExpression("(\\+?( |-|\\.)?\\d{1,2}( |-|\\.)?)?(\\(?\\d{3}\\)?|\\d{3})( |-|\\.)?(\\d{3}( |-|\\.)?\\d{4})",
            ErrorMessage = "Please input a valid, properly formatted phone number including area code")]
        public String Phone { get; set; }
    }
}