using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Return Camel Case
            config.Formatters.JsonFormatter.SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();

            //Return Json
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", "application/json"));
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // Refrence loop Handling
            config.Formatters.JsonFormatter.SerializerSettings
                .ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

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
