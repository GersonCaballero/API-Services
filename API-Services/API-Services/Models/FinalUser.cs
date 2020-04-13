using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class FinalUser
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public String Location { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String Department { get; set; }
        public String Municipality { get; set; }
        public String LocationGPS { get; set; }
        public String CellphoneNumber { get; set; }
    }
}