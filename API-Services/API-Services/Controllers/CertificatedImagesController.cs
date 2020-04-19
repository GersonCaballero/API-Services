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
    public class CertificatedImagesController : ApiController
    {
        private APIServicesContext db = new APIServicesContext();

        // GET: api/CertificatedImages
        public IQueryable<CertificatedImage> GetCertificatedImages()
        {
            return db.CertificatedImages;
        }

        // GET: api/CertificatedImages/5
        [ResponseType(typeof(CertificatedImage))]
        public IHttpActionResult GetCertificatedImage(int id)
        {
            CertificatedImage certificatedImage = db.CertificatedImages.Find(id);
            if (certificatedImage == null)
            {
                return NotFound();
            }

            return Ok(certificatedImage);
        }

        // PUT: api/CertificatedImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCertificatedImage(int id, CertificatedImage certificatedImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != certificatedImage.Id)
            {
                return BadRequest();
            }

            db.Entry(certificatedImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertificatedImageExists(id))
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

        // POST: api/CertificatedImages
        [ResponseType(typeof(CertificatedImage))]
        public IHttpActionResult PostCertificatedImage(CertificatedImage certificatedImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CertificatedImages.Add(certificatedImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = certificatedImage.Id }, certificatedImage);
        }

        // DELETE: api/CertificatedImages/5
        [ResponseType(typeof(CertificatedImage))]
        public IHttpActionResult DeleteCertificatedImage(int id)
        {
            CertificatedImage certificatedImage = db.CertificatedImages.Find(id);
            if (certificatedImage == null)
            {
                return NotFound();
            }

            db.CertificatedImages.Remove(certificatedImage);
            db.SaveChanges();

            return Ok(certificatedImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CertificatedImageExists(int id)
        {
            return db.CertificatedImages.Count(e => e.Id == id) > 0;
        }
    }
}