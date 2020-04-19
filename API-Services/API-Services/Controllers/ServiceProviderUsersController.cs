using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API_Services.Models;

namespace API_Services.Controllers
{
    public class ServiceProviderUsersController : ApiController
    {
        private APIServicesContext db = new APIServicesContext();

        // GET: api/ServiceProviderUsers
        public IQueryable<ServiceProviderUser> GetServiceProviderUsers()
        {
            return db.ServiceProviderUsers;
        }

        // GET: api/ServiceProviderUsers/5
        [ResponseType(typeof(ServiceProviderUser))]
        public IHttpActionResult GetServiceProviderUser(int id)
        {
            ServiceProviderUser serviceProviderUser = db.ServiceProviderUsers.Find(id);
            if (serviceProviderUser == null)
            {
                return NotFound();
            }

            return Ok(serviceProviderUser);
        }

        // PUT: api/ServiceProviderUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceProviderUser(int id, ServiceProviderUser serviceProviderUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceProviderUser.Id)
            {
                return BadRequest();
            }

            db.Entry(serviceProviderUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceProviderUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ServiceProviderUsers
        [ResponseType(typeof(ServiceProviderUser))]
        public IHttpActionResult PostServiceProviderUser(ServiceProviderUser serviceProviderUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceProviderUsers.Add(serviceProviderUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceProviderUser.Id }, serviceProviderUser);
        }

        // DELETE: api/ServiceProviderUsers/5
        [ResponseType(typeof(ServiceProviderUser))]
        public IHttpActionResult DeleteServiceProviderUser(int id)
        {
            ServiceProviderUser serviceProviderUser = db.ServiceProviderUsers.Find(id);
            if (serviceProviderUser == null)
            {
                return NotFound();
            }

            db.ServiceProviderUsers.Remove(serviceProviderUser);
            db.SaveChanges();

            return Ok(serviceProviderUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceProviderUserExists(int id)
        {
            return db.ServiceProviderUsers.Count(e => e.Id == id) > 0;
        }
    }
}