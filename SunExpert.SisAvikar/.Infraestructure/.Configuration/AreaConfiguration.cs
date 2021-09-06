using SunExpert.SisAvikar.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SunExpert.SisAvikar.Repository
{
    internal sealed class AreaConfiguration : EntityTypeConfiguration<Area>
    {
        public AreaConfiguration() : this("dbo") { }

        public AreaConfiguration(string schema)
        {
            ToTable("area", schema);
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            MapToStoredProcedures(x =>
           x.Insert(i =>
               i.HasName("dbo.guardarArea")
               .Parameter(p => p.Descripcion, "Descripcion")
               .Parameter(p => p.Activo, "Activo")
           ).Update(u =>
              u.HasName("dbo.modificarArea")
              .Parameter(p => p.Id, "Id")
              .Parameter(p => p.Descripcion, "Descripcion")
              .Parameter(p => p.Activo, "Activo")

           ));
        }
    }
}
