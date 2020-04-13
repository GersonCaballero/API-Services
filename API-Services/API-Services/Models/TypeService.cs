using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class TypeService
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}