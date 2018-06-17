using CustomerApp.BusinessLayer;
using CustomerApp.DataAccessLayer;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using CustomerApp.App_Start;
using CustomerApp.Data;
//using SimpleInjector;
//using SimpleInjector.Lifestyles;
//using SimpleInjector.Integration.WebApi;

namespace CustomerApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //var container = new Container();
            //container.Register<ICustomerDataAccessLayer, CustomerDataAccessLayer>();
            //container.Register<ICustomerBusinessLayer, CustomerBusinessLayer>();
            //container.Verify();

       

            //DependencyResolver.SetResolver(new SimpleInjectorWebApiDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver( container);

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            //GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            //RegisterGlobalFilters(GlobalFilters.Filters, container);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            //Add simple injector resolved types.
            filters.Add(container.GetInstance<
                CustomerBusinessLayer>());
        }
    }
    
}
