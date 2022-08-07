using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projeto_final
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "PersonRegister",
               "Person/Register",
               new { controller = "Person", action = "Register" }
               );

            routes.MapRoute(
               "PersonAlterar",
               "Person/Alterar/:id",
               new { controller = "Person", action = "Alterar", id=0 }
               );
            routes.MapRoute(
               "PersonDelete",
               "Person/Delete/:id",
               new { controller = "Person", action = "Delete", id = 0 }
               );
            routes.MapRoute(
                "PersonAdicionar",
                "Person/Adicionar",
                new {controller = "Person", action="Adicionar"}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
