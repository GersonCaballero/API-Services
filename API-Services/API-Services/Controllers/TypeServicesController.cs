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
    public class TypeServicesController : ApiController
    {
        private APIServicesContext db = new APIServicesContext();

        // GET: api/TypeServices
        public IQueryable<TypeService> GetTypeServices()
        {
            return db.TypeServices;
        }

        // GET: api/TypeServices/5
        [ResponseType(typeof(TypeService))]
        public IHttpActionResult GetTypeService(int id)
        {
            TypeService typeService = db.TypeServices.Find(id);
            if (typeService == null)
            {
                return NotFound();
            }

            return Ok(typeService);
        }

        // PUT: api/TypeServices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeService(int id, TypeService typeService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeService.Id)
            {
                return BadRequest();
            }

            db.Entry(typeService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeServiceExists(id))
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

        // POST: api/TypeServices
        [ResponseType(typeof(TypeService))]
        public IHttpActionResult PostTypeService(TypeService typeService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeServices.Add(typeService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeService.Id }, typeService);
        }

        // DELETE: api/TypeServices/5
        [ResponseType(typeof(TypeService))]
        public IHttpActionResult DeleteTypeService(int id)
        {
            TypeService typeService = db.TypeServices.Find(id);
            if (typeService == null)
            {
                return NotFound();
            }

            db.TypeServices.Remove(typeService);
            db.SaveChanges();

            return Ok(typeService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeServiceExists(int id)
        {
            return db.TypeServices.Count(e => e.Id == id) > 0;
        }
    }
}