using FacturacionSIM.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FacturacionSIM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//filter config
            RouteConfig.RegisterRoutes(RouteTable.Routes);//Routerconfig
            BundleConfig.RegisterBundles(BundleTable.Bundles);//bun
        }
    }
}
