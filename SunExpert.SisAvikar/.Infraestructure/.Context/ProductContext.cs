using SunExpert.Framework.Sql;
using SunExpert.SisAvikar.Domain.Customize;
using System.Collections.Generic;
using System.Linq;

namespace SunExpert.SisAvikar.Repository
{
    public partial class AvikarContext
    {
        public List<ProductCE> ProductList()
        {
            var reader = SqlHelper.ExecuteDataReader(this
               , "pa_Producto_L"
           );
            List<ProductCE> list = ObjContext.Translate<ProductCE>(reader).ToList();
            return list;
        }
    }
}
