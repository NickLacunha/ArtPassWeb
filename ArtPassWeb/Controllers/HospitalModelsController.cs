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
using ArtPassWeb.Models;

namespace ArtPassWeb.Controllers
{
    public class HospitalModelsController : ApiController
    {
        private ArtPassWebContext db = new ArtPassWebContext();

        // GET: api/HospitalModels
        public IQueryable<HospitalModel> GetHospitalModels()
        {
            return db.HospitalModels;
        }

        // GET: api/HospitalModels/5
        [ResponseType(typeof(HospitalModel))]
        public async Task<IHttpActionResult> GetHospitalModel(int id)
        {
            HospitalModel hospitalModel = await db.HospitalModels.FindAsync(id);
            if (hospitalModel == null)
            {
                return NotFound();
            }

            return Ok(hospitalModel);
        }

        // PUT: api/HospitalModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHospitalModel(int id, HospitalModel hospitalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalModel.HospitalId)
            {
                return BadRequest();
            }

            db.Entry(hospitalModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalModelExists(id))
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

        // POST: api/HospitalModels
        [ResponseType(typeof(HospitalModel))]
        public async Task<IHttpActionResult> PostHospitalModel(HospitalModel hospitalModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HospitalModels.Add(hospitalModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hospitalModel.HospitalId }, hospitalModel);
        }

        // DELETE: api/HospitalModels/5
        [ResponseType(typeof(HospitalModel))]
        public async Task<IHttpActionResult> DeleteHospitalModel(int id)
        {
            HospitalModel hospitalModel = await db.HospitalModels.FindAsync(id);
            if (hospitalModel == null)
            {
                return NotFound();
            }

            db.HospitalModels.Remove(hospitalModel);
            await db.SaveChangesAsync();

            return Ok(hospitalModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalModelExists(int id)
        {
            return db.HospitalModels.Count(e => e.HospitalId == id) > 0;
        }
    }
}