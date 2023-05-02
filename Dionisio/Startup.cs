using Dionisio.Configuration;

namespace Dionisio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddServices(Configuration, env);

        }

        public void Configure(WebApplication app)
        {
            app.UseServices();
        }
    }
}
