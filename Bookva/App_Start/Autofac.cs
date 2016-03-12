using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Business;
using DAL;

namespace Bookva.App_Start
{
    public static class AutofacInitialzer
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterType(typeof(WorksService)).As(typeof (IWorksService)).SingleInstance();
            builder.RegisterType(typeof(BookvaDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (UnitOfWork)).As(typeof (IUnitOfWork)).SingleInstance();
            builder.RegisterType(typeof(AuthorService)).As(typeof(IAuthorService)).SingleInstance();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}