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
    public class RegistrantModelsController : ApiController
    {
        private ArtPassWebContext db = new ArtPassWebContext();

        // GET: api/RegistrantModels
        public IQueryable<RegistrantModel> GetRegistrantModels()
        {
            return db.RegistrantModels;
        }

        // GET: api/RegistrantModels/5
        [ResponseType(typeof(RegistrantModel))]
        public async Task<IHttpActionResult> GetRegistrantModel(int id)
        {
            RegistrantModel registrantModel = await db.RegistrantModels.FindAsync(id);
            if (registrantModel == null)
            {
                return NotFound();
            }

            return Ok(registrantModel);
        }

        // PUT: api/RegistrantModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistrantModel(int id, RegistrantModel registrantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registrantModel.RegistrantId)
            {
                return BadRequest();
            }

            db.Entry(registrantModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrantModelExists(id))
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

        // POST: api/RegistrantModels
        [ResponseType(typeof(RegistrantModel))]
        public async Task<IHttpActionResult> PostRegistrantModel(RegistrantModel registrantModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegistrantModels.Add(registrantModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = registrantModel.RegistrantId }, registrantModel);
        }

        // DELETE: api/RegistrantModels/5
        [ResponseType(typeof(RegistrantModel))]
        public async Task<IHttpActionResult> DeleteRegistrantModel(int id)
        {
            RegistrantModel registrantModel = await db.RegistrantModels.FindAsync(id);
            if (registrantModel == null)
            {
                return NotFound();
            }

            db.RegistrantModels.Remove(registrantModel);
            await db.SaveChangesAsync();

            return Ok(registrantModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistrantModelExists(int id)
        {
            return db.RegistrantModels.Count(e => e.RegistrantId == id) > 0;
        }
    }
}