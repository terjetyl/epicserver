using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MiniCms.Services.RavenDb;
using MiniCms.Web.Code.Handlers;
using MvcHaack.Ajax;

namespace MiniCms.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(new JsonRoute("json/{controller}"));

            routes.MapRoute(
                "Details", // Route name
                "{controller}/{id}/{title}", // URL with parameters
                new { controller = "News", action = "Details" }, new
                {
                    //id = @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$" // guid regex
                    id = @"\d+"
                } // Parameter defaults
            );

            routes.MapRoute(
                "RenderImage", "Images/{file}",
                new { controller = "Images", action = "Render", file = "" }
            );

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);

            RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            RavenInitializer.BuildIndexes();
        }
    }
}