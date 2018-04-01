using ConfigurandoNinject.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YourProjectName.Web.App_Start;

namespace ConfigurandoNinject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Get dependency using ninject
            var kernel = NinjectWebCommon.GetKernel();

            IRepository type = kernel.Get<IRepository>();
            type.GetInt();

        }
    }
}
