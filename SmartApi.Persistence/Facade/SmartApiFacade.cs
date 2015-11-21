using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SmartApi.Persistence.Mappings;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Facade
{
    public class SmartApiFacade : DbContext
    {
        static SmartApiFacade()
        {
            Database.SetInitializer<SmartApiFacade>(null);
        }

        public SmartApiFacade()
            : base("Name=SmartContext")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SmartApiFacade>());
        }

        public DbSet<ArticoliDto> Articoli { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ArticoliMap());
        }
    }
}