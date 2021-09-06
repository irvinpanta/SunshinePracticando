using SunExpert.Framework.DataContext;
using SunExpert.Framework.DataRepository;
using SunExpert.SisAvikar.Domain.Customize;
using SunExpert.SisAvikar.RepositoryInterface;
using System.Collections.Generic;

namespace SunExpert.SisAvikar.Repository
{
    public class AvikarRepository: RepositoryDev, IAvikarRepository
    {
        #region Variables
        protected AvikarContext _DbContext;
        #endregion


        #region Constructor
        public AvikarRepository(IContextDbContext context) : base(context){
            _DbContext = (AvikarContext)context;
        }

        public List<AreaCE> AreaList(){
            return _DbContext.AreaList();
        }

        public List<MesaCE> MesaList()
        {
            return _DbContext.MesaList();
        }

        public List<ProductCE> ProductList()
        {
            return _DbContext.ProductList();
        }


        #endregion

    }
}
