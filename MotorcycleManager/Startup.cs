using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotorcycleManager.Application.Service;
using MotorcycleManager.Application.Service.Impl;
using MotorcycleManager.Domain.Abstraction;
using MotorcycleManager.Domain.Service;
using MotorcycleManager.Domain.Service.Impl;
using MotorcycleManager.Infrastructure.Context;
using MotorcycleManager.Infrastructure.Repository;
using MotorcycleManager.Utilities.Logger;
using NLog;

namespace MotorcycleManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public readonly string CorsAngular = "CorsAngular";

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotorcycleManager.Api", Version = "v1" });
            });

            services.AddDbContext<MotorcycleManagerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MotorcycleManagerConnection")));

            services.AddScoped<IMotorcycleApplicationService, MotorcycleApplicationService>();
            services.AddScoped<IMotorcycleDomainService, MotorcycleDomainService>();
            services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();

            services.AddCors(option => { option.AddPolicy(name: CorsAngular, builder => { builder.AllowAnyOrigin(); }); });
            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotorcycleManager.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
