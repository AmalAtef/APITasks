using OData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //ODATA
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<City>("Cities");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
