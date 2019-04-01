using Microsoft.Extensions.Configuration;

namespace NovaXSoft.Infrastructure.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {
        private readonly IConfiguration configuration;

        public ConfigurationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string DatabaseConnectionString => this.GetConnectionStringValue("SqlConnectionString");        

        public string GetConnectionStringValue(string connStringName)
        {
            return this.configuration.GetConnectionString(connStringName);
        }
    }
}
