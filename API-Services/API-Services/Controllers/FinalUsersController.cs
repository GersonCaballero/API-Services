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
    public class FinalUsersController : ApiController
    {
        private APIServicesContext db = new APIServicesContext();

        // GET: api/FinalUsers
        public IQueryable<FinalUser> GetFinalUsers()
        {
            return db.FinalUsers;
        }

        // GET: api/FinalUsers/5
        [ResponseType(typeof(FinalUser))]
        public IHttpActionResult GetFinalUser(int id)
        {
            FinalUser finalUser = db.FinalUsers.Find(id);
            if (finalUser == null)
            {
                return NotFound();
            }

            return Ok(finalUser);
        }

        // PUT: api/FinalUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFinalUser(int id, FinalUser finalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finalUser.Id)
            {
                return BadRequest();
            }

            db.Entry(finalUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalUserExists(id))
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

        // POST: api/FinalUsers
        [ResponseType(typeof(FinalUser))]
        public IHttpActionResult PostFinalUser(FinalUser finalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FinalUsers.Add(finalUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = finalUser.Id }, finalUser);
        }

        // DELETE: api/FinalUsers/5
        [ResponseType(typeof(FinalUser))]
        public IHttpActionResult DeleteFinalUser(int id)
        {
            FinalUser finalUser = db.FinalUsers.Find(id);
            if (finalUser == null)
            {
                return NotFound();
            }

            db.FinalUsers.Remove(finalUser);
            db.SaveChanges();

            return Ok(finalUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FinalUserExists(int id)
        {
            return db.FinalUsers.Count(e => e.Id == id) > 0;
        }
    }
}