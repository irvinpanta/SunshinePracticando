using CodeFirstStoreFunctions;
using SunExpert.Framework.DataContext;
using SunExpert.SisAvikar.Infraestructure.Configuration;
using System.Data.Entity;

namespace SunExpert.SisAvikar.Repository
{
    //Registramos todos los Configurations del Module
    public partial class AvikarContext : ContextDbContext
    {
        static AvikarContext(){
            Database.SetInitializer<AvikarContext>(null);
        }
        internal AvikarContext() : base() { }
        internal AvikarContext(string nameOrConnectionString) : base(nameOrConnectionString){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AreaConfiguration());
            modelBuilder.Configurations.Add(new MesaConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Conventions.Add(new FunctionsConvention<AvikarContext>("dbo"));

        }
    }
}
