using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RestaurantMaker.App_Start
{
    public class AutofacConfig
    {
        /// <summary>
        /// Registers this instance.
        /// </summary>
        public static void Register()
        {
            //容器建立者
            var builder = new ContainerBuilder();

            //註冊 MVC Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //註冊 Web API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// 註冊相依關係
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Repository"))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Constants"))
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
               .Where(t => t.Name.EndsWith("Client"))
               .AsImplementedInterfaces();

            //建立容器
            var container = builder.Build();

            //建立相依解析器
            var resolverApi = new AutofacWebApiDependencyResolver(container);
            var resolver = new AutofacDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            DependencyResolver.SetResolver(resolver);
        }
    }
}