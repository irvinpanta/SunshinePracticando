using SunExpert.Framework.DataContext;
using SunExpert.Framework.DataRepositoryInterface;
using System;
using System.Collections.Generic;

namespace SunExpert.Framework.DataRepository
{
    //IMPLEMENTA DE IREPOSITORYDEV
    public class RepositoryDev : IRepositoryDev
    {
        #region Variables
        protected IContextDbContext InternalContext { get; set; }
        #endregion

        #region Contructor
        protected RepositoryDev(IContextDbContext context)
        {
            InternalContext = context;
        }
        #endregion

        #region Metodos
        public void Add<T>(T entity) where T : class
        {
            InternalContext.Add(entity);
        }
        public void Add<T>(IEnumerable<T> entities) where T : class
        {
            InternalContext.Add(entities);
        }
        public void Attach<T>(T entity) where T : class
        {
            InternalContext.Attach(entity);
        }
        public void Attach<T>(IEnumerable<T> entities) where T : class
        {
            InternalContext.Attach(entities);
            
        }
        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                InternalContext = null;

            }
        }

        #endregion
    }
}
