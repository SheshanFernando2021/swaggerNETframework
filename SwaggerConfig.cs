using System.Web.Http;
using WebActivatorEx;
using [namespace];
using Swashbuckle.Application; 

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace[namespace] // Replace YourProjectNamespace with your project's namespace
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    // By default, Swashbuckle will exclude controller methods that are decorated with [ApiExplorerSettings(IgnoreApi = true)]
                    // You can also select Controllers and their actions based on custom criteria.
                    // c.GroupActionsBy(apiDesc => apiDesc.HttpMethod.ToString());

                    // Use "SingleApiVersion" to describe a single version API. Swagger UI will also display
                    // a "Select a version" dropdown if you specify more than one.
                    c.SingleApiVersion("v1", "[ProjectName] API"); // Updated API Title

                    // If you want the output Swagger docs to be served on a specific route, enter an HTTP route here.
                    // The route is relative to your application root.
                    // c.SwaggerEndpoint("swagger/v1/swagger.json", "[projectName] API V1"); // Updated API Title V1

                    // ... other configuration options ...

                    // If your API uses XML comments for documentation, you can include them here.
                    // c.IncludeXmlComments(string.Format(@"{0}\bin\[ProjectName].XML", System.AppDomain.CurrentDomain.BaseDirectory)); // Updated Project Name for XML comments
                })
                .EnableSwaggerUi(c =>
                {
                    // Upon launching the Swagger UI, if a selected api-key is specified with a Description,
                    // that description will be displayed above the Petstore API list.
                    // c.EnableApiKeySupport("api_key", "header");
                });
        }
    }
}
