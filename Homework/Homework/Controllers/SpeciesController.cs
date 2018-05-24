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
using Homework.Models;

namespace Homework.Controllers
{
    public class SpeciesController : ApiController
    {
        private homeworkEntities db = new homeworkEntities();

        // GET: api/Species
        [ResponseType(typeof(IEnumerable<Species>))]
        [Route("api/GetSpecies")]
        public IQueryable<Species> GetSpecies()
        {
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.All;

            return db.Species;
        }

        // GET: api/Species/5
        [ResponseType(typeof(Species))]
        [Route("api/GetSpecies/{id}")]
        public IHttpActionResult GetSpecies(int id)
        {
            Species species = db.Species.Find(id);
            if (species == null)
            {
                return NotFound();
            }

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
            Newtonsoft.Json.PreserveReferencesHandling.All;

            return Ok(species);
        }

        // PUT: api/Species/5
        [Route("api/PutSpecies/{id}")]
        public IHttpActionResult PutSpecies(int id, Species species)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != species.ID)
            {
                return BadRequest();
            }

            db.Entry(species).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(species);
        }

        // POST: api/PostSpecies
        [Route("api/PostSpecies")]
        [ResponseType(typeof(Species))]
        public IHttpActionResult PostSpecies(Species species)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Species.Add(species);
            db.SaveChanges();

            return Ok(species);
        }

        // DELETE: api/DeleteSpecies/5
        [Route("api/DeleteSpecies/{id}")]
        [ResponseType(typeof(Species))]
        public IHttpActionResult DeleteSpecies(int id)
        {
            Species species = db.Species.Find(id);
            if (species == null)
            {
                return NotFound();
            }

            db.Species.Remove(species);
            db.SaveChanges();

            return Ok(species);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Route("api/SpeciesExists")]
        private bool SpeciesExists(int id)
        {
            return db.Species.Count(e => e.ID == id) > 0;
        }
    }
}