using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        [ForeignKey(nameof(IdServiceProviderUser))]
        public virtual ServiceProviderUser ServiceProviderUser { get; set; }
        public int IdServiceProviderUser { get; set; }
    }
}