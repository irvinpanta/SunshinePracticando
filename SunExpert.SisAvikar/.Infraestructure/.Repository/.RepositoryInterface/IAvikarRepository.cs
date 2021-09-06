using SunExpert.Framework.DataRepositoryInterface;
using SunExpert.SisAvikar.Domain.Customize;
using System.Collections.Generic;

namespace SunExpert.SisAvikar.RepositoryInterface
{
    //Interface IAvikarRepository Extiende de IRepositoryDev
    public interface IAvikarRepository : IRepositoryDev
    {
        List<AreaCE> AreaList();
        List<MesaCE> MesaList();

        List<ProductCE> ProductList();

    }
}
