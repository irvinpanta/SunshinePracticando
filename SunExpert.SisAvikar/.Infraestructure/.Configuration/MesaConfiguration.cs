using SunExpert.SisAvikar.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.SisAvikar.Infraestructure.Configuration
{
    public class MesaConfiguration: EntityTypeConfiguration<Mesa>
    {
        public MesaConfiguration(): this("dbo"){}

        public MesaConfiguration(string schema)
        {
            ToTable("Mesa")
                .HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("Mesa");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            MapToStoredProcedures(x =>
            x.Insert(i => i
                .HasName("dbo.paAviMesaMantenimiento")
                .Parameter(p => p.xFlag, "1")
                .Parameter(p => p.Descripcion, "Descripcion")
                .Parameter(p => p.Cantidad, "Cantidad")
                .Parameter(p => p.Activo, "Activo")
                .Parameter(p => p.MesaRapida, "Defecto")
            ).Update(u => u
                .HasName("dbo.paAviMesaMantenimiento")
                .Parameter(p => p.xFlag, "1")
                .Parameter(p => p.Id, "Mesa")
                .Parameter(p => p.Descripcion, "Descripcion")
                .Parameter(p => p.Cantidad, "Cantidad")
                .Parameter(p => p.Activo, "Activo")
                .Parameter(p => p.MesaRapida, "Defecto")
            )); ;
        }
    }
}
