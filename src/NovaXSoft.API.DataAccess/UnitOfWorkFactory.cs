using NovaXSoft.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using NovaXSoft.API.DataAccess.Abstraction;
using NovaXSoft.API.DataAccess.DataContext;
using System;

namespace NovaXSoft.API.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IConfigurationManager configurationManager;

        private readonly IServiceProvider serviceProvider;

        public UnitOfWorkFactory(
            IConfigurationManager configurationManager,
            IServiceProvider serviceProvider)
        {
            this.configurationManager = configurationManager;
            this.serviceProvider = serviceProvider;
        }
        public IUnitOfWork CreateUnitOfWork()
        {
            var dbContext = this.CreateDbContext();
            var unitOfWork = new UnitOfWork(dbContext, this.serviceProvider);

            return unitOfWork;
        }

        private DbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<NovaXSoftDbContext>()
                .UseSqlServer(configurationManager.DatabaseConnectionString)
                .Options;
            DbContext dbContext = new NovaXSoftDbContext(dbContextOptions);

            return dbContext;
        }
    }
}
