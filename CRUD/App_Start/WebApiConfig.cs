using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using CRUD.Models;

namespace CRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<tbl_MHead>("tbl_MHead");
            builder.EntitySet<tbl_Head>("tbl_Head");
            builder.EntitySet<tbl_PartyCateg>("tbl_PartyCateg");
            builder.EntitySet<tbl_Party>("tbl_Party");
            builder.EntitySet<tbl_Ledger>("tbl_Ledger");
            builder.EntitySet<tbl_PartyType>("tbl_PartyType");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

        }
    }
}
