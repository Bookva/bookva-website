using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Bookva.Business;
using Bookva.DAL;
using Bookva.Business.ImageService;
using Bookva.Business.Identity;

namespace Bookva.Web
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
            builder.RegisterType(typeof(ImageService)).As(typeof(IImageService)).SingleInstance();
            builder.RegisterType(typeof(ReviewService)).As(typeof(IReviewService)).SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}