using SunExpert.Framework.ConnectionSecurity;
using SunExpert.Framework.DataContext;
using SunExpert.Framework.DataUoW;
using SunExpert.SisAvikar.Repository.Repository;
using SunExpert.SisAvikar.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.SisAvikar.Repository.UoW
{
    public class AvikarUoW : UoWDev, IAvikarUoW, IDisposable
    {
        private IAvikarRepository _AvikarRepository;

        public AvikarUoW(){
            InternalContext = (IContextDbContext)AvikarContextFactory.GetContext(SunExpertConnection.GetConnectionApp());

            _AvikarRepository = AvikarRepositoryFactory.DinningHallRepository(InternalContext);
        }
        public IAvikarRepository AvikarRepository
        {
            get
            {
                return _AvikarRepository;
            }
        }
        #region IDisposable
        public void Dispose(){
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing){
                _AvikarRepository = null;
            }
            base.Dispose();
        }
        #endregion
    }
}
