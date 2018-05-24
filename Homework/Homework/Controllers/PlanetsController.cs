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
    public class PlanetsController : ApiController
    {
        private homeworkEntities db = new homeworkEntities();

        // GET: api/GetPlanets
        [ResponseType(typeof(IEnumerable<Planet>))]
        [Route("api/GetPlanets")]
        public IQueryable<Planet> GetPlanets()
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.All;
            return db.Planets;
        }

        // GET: api/GetPlanet/5
        [ResponseType(typeof(IEnumerable<Planet>))]
        [Route("api/GetPlanet/{id}")]
        public IHttpActionResult GetPlanet(int id)
        {
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return NotFound();
            }

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.All;
            return Ok(planet);
        }

        // PUT: api/Planet/5
        [Route("api/PutPlanet/{id}")]
        public IHttpActionResult PutPlanet(int id, Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != planet.ID)
            {
                return BadRequest();
            }

            db.Entry(planet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(planet);
        }

        // POST: api/PostPlanet
        [Route("api/PostPlanet")]
        [ResponseType(typeof(Planet))]
        public IHttpActionResult PostPlanet(Planet planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Planets.Add(planet);
            db.SaveChanges();

            return Ok(planet);
        }

        // DELETE: api/DeletePlanet/5
        [Route("api/DeletePlanet/{id}")]
        [ResponseType(typeof(Planet))]
        public IHttpActionResult DeletePlanet(int id)
        {
            Planet planet = db.Planets.Find(id);
            if (planet == null)
            {
                return NotFound();
            }

            db.Planets.Remove(planet);
            db.SaveChanges();

            return Ok(planet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Route("api/PlanetExists")]
        private bool PlanetExists(int id)
        {
            return db.Planets.Count(e => e.ID == id) > 0;
        }
    }
}