
using SunExpert.SisAvikar.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SunExpert.SisAvikar.Infraestructure.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration() :this("dbo")
        {

        }
        public ProductConfiguration(string schema)
        {
            ToTable("Productos");
            HasKey(x => x.ProId);
            Property(x => x.ProId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            MapToStoredProcedures(x =>
            x.Insert( i => i
                .HasName("dbo.pa_Producto_I")
                //.Parameter(p => p.ProId, "ProId")
                .Parameter(p=> p.ProDescripcion, "ProDescripcion")
                .Parameter(p => p.ProStock, "ProStock")
                .Parameter(p => p.ProPrecio, "ProPrecio")
                .Parameter(p => p.ProActivo, "ProActivo")
                .Parameter(p => p.FamProId, "FamProId")
            ).Update(u => u
                .HasName("dbo.pa_Producto_U")
                .Parameter(p => p.ProId, "ProId")
                .Parameter(p => p.ProDescripcion, "ProDescripcion")
                .Parameter(p => p.ProStock, "ProStock")
                .Parameter(p => p.ProPrecio, "ProPrecio")
                .Parameter(p => p.ProActivo, "ProActivo")
                .Parameter(p => p.FamProId, "FamProId")
            ));
        }
    }
}
