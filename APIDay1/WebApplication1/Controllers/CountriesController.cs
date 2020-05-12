using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.POCO;

namespace WebApplication1.Controllers
{
    public class CountriesController : ApiController
    {
        private Entities ctx = new Entities();

        //GET: api/Countries
    public List<Country> GetCountries()
        {
            return ctx.Countries.ToList();
            //return ctx.Countries.Select(c => new CountryPOCO
            //{
            //    id = c.id,
            //    name = c.name,
            //    Cities = c.Cities.Select(s => new CityPOCO {
            //        id=s.id,
            //        name=s.name,
            //        countryId=s.countryId
            //    }).ToList()
            //}).ToList();
        }
        //POST :api/Countries
        public Country PostCountry(Country c)
        {
           var res= ctx.Countries.Add(c);
            ctx.SaveChanges();
            return c;
        }


    }
}
