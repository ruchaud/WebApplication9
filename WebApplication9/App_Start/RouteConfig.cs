using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication9
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
               // defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                  "Pessoa",                                              // Route name
                  "{controller}/{action}/{id}",                           // URL with parameters
                  new { controller = "Pessoas", action = "Index", id = "" }  // Parameter defaults
              );
                routes.MapRoute(
                 "Endereco",                                              // Route name
                 "{controller}/{action}/{id}",                           // URL with parameters
                 new { controller = "Enderecos", action = "Index", id = UrlParameter.Optional }  // Parameter defaults
             );
                routes.MapRoute(
                 "Estado",                                              // Route name
                 "{controller}/{action}/{id}",                           // URL with parameters
                 new { controller = "Estados", action = "Index", id = "" }  // Parameter defaults
             );
                routes.MapRoute(
                "Cidade",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Cidades", action = "Index", id = "" }  // Parameter defaults
            );
                routes.MapRoute(
                 "Bairro",                                              // Route name
                 "{controller}/{action}/{id}",                           // URL with parameters
             new { controller = "Bairroes", action = "Index", id = "" }  // Parameter defaults
             );
                routes.MapRoute(
                "Posicao",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
              new { controller = "Posicoes", action = "Index", id = "" }  // Parameter defaults
             );
                routes.MapRoute(
              "TipoCadastro",                                              // Route name
              "{controller}/{action}/{id}",                           // URL with parameters
            new { controller = "TipoCadastros", action = "Index", id = "" }  // Parameter defaults
           );
        
    }
    }
}
