using SunExpert.SisAvikar.Domain;
using SunExpert.SisAvikar.Domain.Customize;
using SunExpert.SisAvikar.Domain.Entity;
using System.Collections.Generic;

namespace SunExpert.SisAvikar.ServiceInterface
{
    public interface IAvikarService 
    {
        #region Area
        List<AreaCE> AreaList(); //Listar Areas
        int AreaSave(Area obj); //Grabar y/o Modificar registros
        #endregion

        #region Mesa
        List<MesaCE> MesaList();
        int MesaSave(Mesa obj); //Grabar y/o Modificar registros
        #endregion

        List<ProductCE> ProductList();
        int ProductSave(Product obj);
    }
}
