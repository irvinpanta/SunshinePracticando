using SunExpert.Framework.Sql;
using SunExpert.SisAvikar.Domain.Customize;
using System.Collections.Generic;
using System.Linq;

namespace SunExpert.SisAvikar.Repository
{
    public partial class AvikarContext
    {
        public List<MesaCE> MesaList()
        {
            var reader = SqlHelper.ExecuteDataReader(this
               , "paAviMesaConsultar"
               , SqlHelper.SqlParameter("xFlag", "1")
               , SqlHelper.SqlParameter("xCriterio", "")

           );
            List<MesaCE> list = ObjContext.Translate<MesaCE>(reader).ToList();
            return list;
        }
    }
}
