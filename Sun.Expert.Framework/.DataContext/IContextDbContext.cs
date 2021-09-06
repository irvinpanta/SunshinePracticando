using SunExpert.Framework.Enun;
using System;
using System.Collections.Generic;

namespace SunExpert.Framework.DataContext
{
    //IContextDbContext Implementa de Interface IDisposable
    public interface IContextDbContext: IDisposable
    {
        //bool FindById(int id);
        void Add<T>(T entity) where T : class;
        void Add<T>(IEnumerable<T> entities) where T : class;
        void Attach<T>(T entity) where T : class;
        void Attach<T>(IEnumerable<T> entities) where T : class;
        void BeginTransaction();
        void ChangeState<T>(T entity, EFEntityState state);
        void ChangeStateRange<T>(IEnumerable<T> entities, EFEntityState state);
        void Commit();
        void Reload<T>(T entity);
        void Rollback();
        int SaveChanges();
        void SaveChangesTransaction();

    }
}
