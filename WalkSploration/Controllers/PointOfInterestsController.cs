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
using WalkSploration.Models;

namespace WalkSploration.Controllers
{
    public class PointOfInterestsController : ApiController
    {




        //  Referencing Detroit Eatz Project



        // End refrence of Detroit Eatz project


        // static readonly Dictionary<Guid, InputInfo> inputInfo = new Dictionary<Guid, InputInfo>();

        //        [HttpPost]
        //        [ActionName("Complex")]
        //        public HttpResponseMessage PostComplex(InputInfo inputInfo)
        //        {
        //            if (ModelState.IsValid && inputInfo != null)
        //            {
        //                // Convert any HTML markup in the status text.
        //                string tempVar = inputInfo.TimeIn.ToString();
        //                tempVar = HttpResponseMessage.Utility.HtmlEncode(inputInfo.TimeIn);

        //                // Create a 201 response.
        //                var response = new HttpResponseMessage(HttpStatusCode.Created)
        //                {
        //                    Content = new StringContent (inputInfo.TimeIn.ToString())
        //                };

        //                response.Headers.Location =
        //                    new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
        //                return response;
        //            }
        //            else
        //            {
        //                return Request.CreateResponse(HttpStatusCode.BadRequest);
        //            }
        //        }

        //        [HttpGet]
        //        public InputInfo TimeIn(Guid id)
        //        {
        //            InputInfo inputInfo;
        //            if (inputInfo.TryGetValue(id, out inputInfo))
        //            {
        //                return inputInfo;
        //            }
        //            else
        //            {
        //                throw new HttpResponseException(HttpStatusCode.NotFound);
        //            }
        //        }
        //    }
        //}




            //[HttpPost]
            //public ActionResult SaveComments(int time, decimal startLat, decimal startLong)
            //{
            //    //Grand Circus 42.3347, -83.0497; this is just a placeholder until actual start location set
            //    Location start = new Location(startLat, startLong);

            //    Debug.WriteLine("time: " + time + "   Start latitude: " + startLat + "    Start Longitude: " + startLong);
            //    List<PointOfInterest> goldilocks = screenPlaces(getPlaces(start, time), start, time);
            //    return View();
            //}


        //// GET: api/PointOfInterests
        //public IQueryable<PointOfInterest> GetPOI([FromUri] List<decimal> idList)
        //{
            

        //    return pointOfInterests;
        //}

//        // GET: api/PointOfInterests/5
//        [ResponseType(typeof(PointOfInterest))]
//        public async Task<IHttpActionResult> GetPointOfInterest(int id)
//        {
//            PointOfInterest pointOfInterest = await db.PointOfInterests.FindAsync(id);
//            if (pointOfInterest == null)
//            {
//                return NotFound();
//            }

//            return Ok(pointOfInterest);
//        }

//        // PUT: api/PointOfInterests/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutPointOfInterest(int id, PointOfInterest pointOfInterest)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != pointOfInterest.Id)
//            {
//                return BadRequest();
//            }

//            db.Entry(pointOfInterest).State = EntityState.Modified;

//            try
//            {
//                await db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!PointOfInterestExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/PointOfInterests
//        [ResponseType(typeof(PointOfInterest))]
//        public async Task<IHttpActionResult> PostPointOfInterest(PointOfInterest pointOfInterest)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            db.PointOfInterests.Add(pointOfInterest);
//            await db.SaveChangesAsync();

//            return CreatedAtRoute("DefaultApi", new { id = pointOfInterest.Id }, pointOfInterest);
//        }

//        // DELETE: api/PointOfInterests/5
//        [ResponseType(typeof(PointOfInterest))]
//        public async Task<IHttpActionResult> DeletePointOfInterest(int id)
//        {
//            PointOfInterest pointOfInterest = await db.PointOfInterests.FindAsync(id);
//            if (pointOfInterest == null)
//            {
//                return NotFound();
//            }

//            db.PointOfInterests.Remove(pointOfInterest);
//            await db.SaveChangesAsync();

//            return Ok(pointOfInterest);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool PointOfInterestExists(int id)
//        {
//            return db.PointOfInterests.Count(e => e.Id == id) > 0;
//        }
    }
}