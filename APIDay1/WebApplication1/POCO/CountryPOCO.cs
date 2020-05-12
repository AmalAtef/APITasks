using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.POCO
{
    public class CountryPOCO
    {
        public decimal id { get; set; }
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CityPOCO> Cities { get; set; }
    }
}