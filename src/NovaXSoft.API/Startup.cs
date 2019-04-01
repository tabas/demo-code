using AutoMapper;
using NovaXSoft.Infrastructure.Configuration;
using NovaXSoft.API.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovaXSoft.API.Domain.Mappers;
using NovaXSoft.API.Configuration.Swagger;
using NovaXSoft.API.Configuration;

namespace NovaXSoft.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {   
            this.Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.ConfigureSwagger();
            services.RegisterServices();
            services.AddAutoMapper(typeof(StudentProfile).Assembly);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            }

            app.ConfigureSwagger(env);

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();
            app.UseMvc();
        }

        private IConfigurationManager GetConfigurationManager(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            IConfigurationManager config = serviceProvider.GetService<IConfigurationManager>();

            return config;
        }
    }
}
