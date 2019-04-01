using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NovaXSoft.API.DataAccess.Mapping;
using NovaXSoft.API.Domain.Entities;

namespace NovaXSoft.API.DataAccess.DataContext
{
    public class NovaXSoftDbContext : DbContext
    {
        public NovaXSoftDbContext(DbContextOptions<NovaXSoftDbContext> options)
            : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TraceLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
#endif

            base.OnConfiguring(optionsBuilder);
        }
    }
}
