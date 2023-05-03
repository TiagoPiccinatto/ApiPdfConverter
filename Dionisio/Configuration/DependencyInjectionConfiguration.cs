using AutoMapper;
using Dionisio.Data.Context;
using Dionisio.Infra;
using Microsoft.EntityFrameworkCore;

namespace Dionisio.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddControllers();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfiles()); });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            IoC.RegisterServices(services);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://127.0.0.1:5173")
                                                        .AllowAnyHeader()
                                                        .AllowAnyMethod();
                                  });
            });

            services.AddDbContext<PdfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void UseServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MyAllowSpecificOrigins");

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
