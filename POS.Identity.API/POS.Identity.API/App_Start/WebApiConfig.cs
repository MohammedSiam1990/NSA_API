using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;
using POS.API.Models;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;

namespace POS.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            //string origin = "http://localhost:10047/";
            config.Routes.MapHttpRoute(
            name: "RegisterRoute",
            routeTemplate: "api/controller/action;{model}",
            defaults: new
            {
                controller = "Account",
                action = "Register",
                username = RouteParameter.Optional,
                password = RouteParameter.Optional
            }
           // constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );
            // Web API routes
            config.MapHttpAttributeRoutes();
                 config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            // var cors = new EnableCorsAttribute(origin, "*", "*");
            //config.EnableCors(cors);
            //var constraints = new { httpMethod = new HttpMethodConstraint(HttpMethod.Options) };
            //config.Routes.IgnoreRoute("OPTIONS", "*pathInfo", constraints);

            //config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            //config.EnableCors();
            //  GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //  config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //var JsonpFormater = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, JsonpFormater);
        }
    }
}
