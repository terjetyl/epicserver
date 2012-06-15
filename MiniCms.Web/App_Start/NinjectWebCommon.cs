using System.Web.Http;
using MiniCms.Model;
using MiniCms.Model.Repositories;
using MiniCms.Services;
using MiniCms.Services.RavenDb;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Thinktecture.Web.Http.Formatters;

[assembly: WebActivator.PreApplicationStartMethod(typeof(MiniCms.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(MiniCms.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MiniCms.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new NinjectSettings { LoadExtensions = false });
            kernel.Load(new Ninject.Web.Mvc.MvcModule());
            kernel.Load(new Ninject.Web.WebApi.WebApiModule());
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            var config = GlobalConfiguration.Configuration;
            RegisterApis(config);
            RegisterServices(kernel);
            return kernel;
        }

        public static void RegisterApis(HttpConfiguration config)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new IsoDateTimeConverter());

            config.Formatters[0] = new JsonNetFormatter(serializerSettings);
            //config.Formatters.Add(new ProtoBufFormatter());
            //config.Formatters.Add(new ContactPngFormatter());
            //config.Formatters.Add(new VCardFormatter());
            //config.Formatters.Add(new ContactCalendarFormatter());

            //config.MessageHandlers.Add(new UriFormatExtensionHandler(new UriExtensionMappings()));
            //config.MessageHandlers.Add(new LoggingHandler());
            //config.MessageHandlers.Add(new NotAcceptableHandler());

            //ConfigureResolver(config);
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBlogRepository>().To<BlogRepository>();
            kernel.Bind<IBlogPostRepository>().To<BlogPostRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<INewsletterSubscriberRepository>().To<NewsletterSubscriberRepository>();
            kernel.Bind<INewsletterRepository>().To<NewsletterRepository>();
            kernel.Bind<IContentRepository>().To<ContentRepository>();
            kernel.Bind<IFeatureRepository>().To<FeatureRepository>();
            kernel.Bind<IMailService>().To<MailService>();
        }        
    }
}
