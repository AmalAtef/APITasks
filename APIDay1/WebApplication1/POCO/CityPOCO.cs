using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.POCO
{
    public class CityPOCO
    {
        public decimal id { get; set; }
        public string name { get; set; }
        public decimal countryId { get; set; }

        public virtual CountryPOCO Country { get; set; }
    }
}