using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
namespace ServiciosNacionCrema
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "rest/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
		
		}
    }
}
