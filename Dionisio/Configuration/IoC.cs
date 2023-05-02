using Dionisio.Application.Interface.Repository;
using Dionisio.Application.Interface.Sevice;
using Dionisio.Application.Service;
using Dionisio.Infra.Repository;

namespace Dionisio.Configuration
{
    public class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Base Repository - Base Service
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IPdfRepository, PdfRepository>();
        }
    }
}
