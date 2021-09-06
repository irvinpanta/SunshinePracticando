using SunExpert.Framework.Sql;
using SunExpert.SisAvikar.Domain.Customize;
using System.Collections.Generic;
using System.Linq;

namespace SunExpert.SisAvikar.Repository
{
    public partial class AvikarContext
    {
        public List<AreaCE> AreaList()
        {
            var reader = SqlHelper.ExecuteDataReader(this
               , "consultarArea"
           );
            List<AreaCE> list = ObjContext.Translate<AreaCE>(reader).ToList();
            return list;
        }
    }
}
