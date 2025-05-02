using Autofac;
using Autofac.Integration.WebApi;
using [namespace].Data; // Assuming your AppDbContext is in this namespace
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Routing;

namespace [namespace]
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the ContainerBuilder.
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            // Assembly.GetExecutingAssembly() gets the assembly where your Global.asax.cs is located.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register your AppDbContext.
            // Use InstancePerRequest for DbContext to ensure a new instance per HTTP request.
            // Assuming your AppDbContext has a constructor that takes a connection string name
            // or a parameterless constructor that calls base("name=DefaultConnection").
            builder.RegisterType<AppDbContext>()
                   .AsSelf() // Register as itself so you can inject AppDbContext directly
                   .InstancePerRequest();

            // Optionally, if you have an interface for your DbContext (e.g., IAppDbContext)
            // builder.RegisterType<AppDbContext>().As<IAppDbContext>().InstancePerRequest();

            // Build the container.
            var container = builder.Build();

            // Set the Dependency Resolver for Web API.
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Configure your Web API routes (this part is standard).
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
