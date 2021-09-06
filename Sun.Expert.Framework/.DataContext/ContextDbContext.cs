using SunExpert.Framework.Enun;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace SunExpert.Framework.DataContext
{
    //ContextDbContext Hereda de DbContext(EntityFramework) e Implementa de IContextDbContext
    public class ContextDbContext : DbContext, IContextDbContext
    {

        #region Fields
        private DbContextTransaction _transaction = null;
        #endregion

        #region Constructor
        public ContextDbContext() : base()
        {
            InitializeContext();
        }

        public ContextDbContext(string connectionString) : base(connectionString)
        {
            InitializeContext();
        }

        #endregion

        #region Metodos
        public ObjectContext ObjContext { get; set; }
        protected void InitializeContext()
        {
            ObjContext = ((IObjectContextAdapter)this).ObjectContext;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {

                throw e.GetBaseException();
            }
        }
        public void SaveChangesTransaction()
        {
            int result = 0;
            try{

                Database.BeginTransaction();
                result = base.SaveChanges();
                Database.CurrentTransaction.Commit();

            }catch (Exception e){
                
                if (Database.CurrentTransaction != null)
                    Database.CurrentTransaction.Rollback();
                throw e.GetBaseException();
            }
        }
        public void ChangeState<T>(T entity, EFEntityState state)
        {
            this.Entry(entity).State = GetState(state);
        }
        public void ChangeState<T>(ICollection<T> entities, EFEntityState state)
        {
            foreach (T entity in entities)
                ChangeState(entity, state);
        }
        public void ChangeStateRange<T>(IEnumerable<T> entities, EFEntityState state)
        {
            foreach (T entity in entities)
                ChangeState(entity, state);
        }
        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                //   _transaction.Dispose();
                _transaction = null;
            }
            _transaction = Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
            //  _transaction.Dispose();
            _transaction = null;
        }
        public void Rollback()
        {
            _transaction.Rollback();
            //   _transaction.Dispose();
            _transaction = null;
        }
        public void Add<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }
        public void Add<T>(IEnumerable<T> entities) where T : class
        {
            Set<T>().AddRange(entities);
        }
        public void Attach<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            //Entry(entity).State = GetState(EFEntityState.Modified);
            ChangeTracking();

        }
        private void ChangeTracking()
        {
            //IEnumerable<DbEntityEntry> changedEntries = this.ChangeTracker.Entries();

            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                EntitySetBase setBase = ObjContext.ObjectStateManager.GetObjectStateEntry(entry.Entity).EntitySet;

                string[] keyNames = setBase.ElementType.KeyMembers.Select(k => k.Name).ToArray();
                string keyName;
                if (keyNames != null)
                {
                    keyName = keyNames.FirstOrDefault();
                    Type type = entry.CurrentValues[keyName].GetType();
                    if (type.Equals(typeof(int)))
                    {
                        if (entry.CurrentValues.GetValue<int>(keyName) > 0)
                            entry.State = EntityState.Modified;
                        else
                            entry.State = EntityState.Added;
                    }
                    else if (entry.CurrentValues.GetValue<int>("UsrUpdateID") == 0)
                        entry.State = EntityState.Added;
                    else entry.State = EntityState.Modified;
                }

            }
        }
        public void Attach<T>(IEnumerable<T> entities) where T : class
        {
            Set<T>().AddRange(entities);
            //foreach (T entity in entities)
            //    Set<T>().Attach(entity);

            ChangeTracking();
        }
        public void Reload<T>(T entity)
        {
            this.Entry(entity).Reload();
        }
        private EntityState GetState(EFEntityState state)
        {
            switch (state)
            {
                case EFEntityState.Added:
                    return EntityState.Added;
                case EFEntityState.Modified:
                    return EntityState.Modified;
                case EFEntityState.Detached:
                    return EntityState.Detached;
                default:
                    return EntityState.Unchanged;
            }
        }
        #endregion

        #region IDispose
        protected override void Dispose(bool disposing)
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            _transaction = null;
            base.Dispose(disposing);
        }
        #endregion
    }
}
