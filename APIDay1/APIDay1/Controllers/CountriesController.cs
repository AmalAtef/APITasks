using APIDay1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIDay1.Controllers
{
    public class CountriesController : ApiController
    {
        private Entities ctx = new Entities();

        //Get : api/countries
        public List<Country> GetCountries()
        {
            return ctx.Countries.ToList();
        }

    }
}
