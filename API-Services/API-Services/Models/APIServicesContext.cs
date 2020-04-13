using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_Services.Models
{
    public class APIServicesContext : DbContext
    {
        public APIServicesContext() : base("name=APIServicesContext")
        {
        }

        public DbSet<TypeService> TypeServices { get; set; }
        public DbSet<CertificatedImage> CertificatedImages { get; set; }
        public DbSet<FinalUser> FinalUsers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProviderUser> ServiceProviderUsers { get; set; }
    }
}