using SunExpert.Framework.DataContext;
using SunExpert.Framework.DataUoWInterface;
using SunExpert.Framework.Enun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.Framework.DataUoW
{
    public abstract class UoWDev : IUoWDev
    {
        #region Constructor
        protected UoWDev() { }
        #endregion

        #region Public/protected properties
        protected IContextDbContext InternalContext { get; set; }
        #endregion
        #region Public/protected methods

        //public bool FindById(int id)
        //{
        //    return InternalContext.FindById(id);
        //}
        public int SaveChanges()
        {
            return InternalContext.SaveChanges();
        }
        public void SaveChangesTransaction()
        {
            InternalContext.SaveChangesTransaction();
        }
        public void ChangeState<T>(T entity, EFEntityState state)
        {
            InternalContext.ChangeState(entity, state);
        }
        public void ChangeState<T>(ICollection<T> entities, EFEntityState state)
        {
            InternalContext.ChangeState(entities, state);
        }
        public void BeginTransaction()
        {
            InternalContext.BeginTransaction();
        }
        public void Commit()
        {
            InternalContext.Commit();
        }
        public void Rollback()
        {
            InternalContext.Rollback();
        }
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
        public void Reload<T>(T entity)
        {
            InternalContext.Reload(entity);
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
            if (disposing){
                if (InternalContext != null){
                    InternalContext.Dispose();
                }
                InternalContext = null;
            }
        }
        #endregion
    }
}
