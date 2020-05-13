using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using OData.Models;

namespace OData.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using OData.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Country>("Countries");
    builder.EntitySet<City>("Cities"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CountriesController : ODataController
    {
        private Entities db = new Entities();

        // GET: odata/Countries
        [EnableQuery]
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        // GET: odata/Countries(5)
        [EnableQuery]
        public SingleResult<Country> GetCountry([FromODataUri] decimal key)
        {
            return SingleResult.Create(db.Countries.Where(country => country.id == key));
        }

        // PUT: odata/Countries(5)
        public IHttpActionResult Put([FromODataUri] decimal key, Delta<Country> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country country = db.Countries.Find(key);
            if (country == null)
            {
                return NotFound();
            }

            patch.Put(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(country);
        }

        // POST: odata/Countries
        public IHttpActionResult Post(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CountryExists(country.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(country);
        }

        // PATCH: odata/Countries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] decimal key, Delta<Country> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country country = db.Countries.Find(key);
            if (country == null)
            {
                return NotFound();
            }

            patch.Patch(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(country);
        }

        // DELETE: odata/Countries(5)
        public IHttpActionResult Delete([FromODataUri] decimal key)
        {
            Country country = db.Countries.Find(key);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Countries(5)/Cities
        [EnableQuery]
        public IQueryable<City> GetCities([FromODataUri] decimal key)
        {
            return db.Countries.Where(m => m.id == key).SelectMany(m => m.Cities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(decimal key)
        {
            return db.Countries.Count(e => e.id == key) > 0;
        }
    }
}
