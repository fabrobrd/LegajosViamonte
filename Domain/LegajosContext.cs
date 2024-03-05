using Legajos.Domain.Mapping;
using Legajos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Legajos.Domain
{
    public class LegajosContext:DbContext
    {
        public LegajosContext(DbContextOptions options):base(options)
        {
                
        }
        public LegajosContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(ConfigurationHelper.ViamonteConnetionString))
                ConfigurationHelper.ViamonteConnetionString = "Server=192.168.2.29;Database=VIAMONTE;User ID = usuariotest;Password=open1234;Application Name = RRHH_Cafe_Viamonte";

            optionsBuilder.UseSqlServer(ConfigurationHelper.ViamonteConnetionString)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        public DbSet<Rrhh> Rrhhs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RrhhConfig());
        }
    }
}
