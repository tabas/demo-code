using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using NovaXSoft.API.DataAccess;
using NovaXSoft.API.DataAccess.Abstraction;
using NovaXSoft.API.DataAccess.Abstraction.Repository;
using NovaXSoft.API.DataAccess.Repository;
using NovaXSoft.API.Services;
using NovaXSoft.API.Services.Abstraction;
using NovaXSoft.Infrastructure.Configuration;

namespace NovaXSoft.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddTransient<IConfigurationManager, ConfigurationManager>();
            services.AddTransient<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IStudentsService, StudentsService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory =>
            {
                var actionContext = factory.GetService<IActionContextAccessor>()
                                           .ActionContext;
                return new UrlHelper(actionContext);
            });

            return services;
        }
    }
}
