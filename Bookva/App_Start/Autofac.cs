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

            builder.RegisterType(typeof(WorksService)).As(typeof (IWorksService)).InstancePerRequest();
            builder.RegisterType(typeof(BookvaDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof (UnitOfWork)).As(typeof (IUnitOfWork)).InstancePerRequest();
            builder.RegisterType(typeof(AuthorService)).As(typeof(IAuthorService)).InstancePerRequest();
            builder.RegisterType(typeof(ImageService)).As(typeof(IImageService)).InstancePerRequest();
            builder.RegisterType(typeof(ReviewService)).As(typeof(IReviewService)).InstancePerRequest();
            builder.RegisterType(typeof (KeywordService)).As(typeof (IKeywordService)).InstancePerRequest();
            builder.RegisterType(typeof(GenreService)).As(typeof(IGenreService)).InstancePerRequest();
            builder.RegisterType(typeof(CollectionsService)).As(typeof(ICollectionsService)).InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}