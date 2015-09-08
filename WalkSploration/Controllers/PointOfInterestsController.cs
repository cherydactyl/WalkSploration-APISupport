using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WalkSploration.Models;

namespace WalkSploration.Controllers
{
    public class PointOfInterestsController : ApiController
    {
        private WalkSplorationContext db = new WalkSplorationContext();

        // GET: api/PointOfInterests
        public IQueryable<PointOfInterest> GetPointOfInterests()
        {
            return db.PointOfInterests;
        }

        // GET: api/PointOfInterests/5
        [ResponseType(typeof(PointOfInterest))]
        public async Task<IHttpActionResult> GetPointOfInterest(int id)
        {
            PointOfInterest pointOfInterest = await db.PointOfInterests.FindAsync(id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        // PUT: api/PointOfInterests/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPointOfInterest(int id, PointOfInterest pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pointOfInterest.PointOfInterestId)
            {
                return BadRequest();
            }

            db.Entry(pointOfInterest).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointOfInterestExists(id))
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

        // POST: api/PointOfInterests
        [ResponseType(typeof(PointOfInterest))]
        public async Task<IHttpActionResult> PostPointOfInterest(PointOfInterest pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PointOfInterests.Add(pointOfInterest);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pointOfInterest.PointOfInterestId }, pointOfInterest);
        }

        // DELETE: api/PointOfInterests/5
        [ResponseType(typeof(PointOfInterest))]
        public async Task<IHttpActionResult> DeletePointOfInterest(int id)
        {
            PointOfInterest pointOfInterest = await db.PointOfInterests.FindAsync(id);
            if (pointOfInterest == null)
            {
                return NotFound();
            }

            db.PointOfInterests.Remove(pointOfInterest);
            await db.SaveChangesAsync();

            return Ok(pointOfInterest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PointOfInterestExists(int id)
        {
            return db.PointOfInterests.Count(e => e.PointOfInterestId == id) > 0;
        }
    }
}