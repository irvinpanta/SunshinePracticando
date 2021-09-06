using SunExpert.Framework.Enun;
using System;
using System.Collections.Generic;

namespace SunExpert.Framework.DataUoWInterface
{
    //Implementa de IDisposable
    public interface IUoWDev: IDisposable
    {
        //bool FindById(int id);
        //Metodo Generico para Guardar
        void Add<T>(T entity) where T : class;
        void Add<T>(IEnumerable<T> entities) where T : class;

        //Metodo Generico para Modificar
        void Attach<T>(T entity) where T : class;
        void Attach<T>(IEnumerable<T> entities) where T : class;
        
        void BeginTransaction();
        void ChangeState<T>(T entity, EFEntityState state);
        void ChangeState<T>(ICollection<T> entities, EFEntityState state);
        void Commit();
        void Reload<T>(T entity);
        void Rollback();

        //Metodo para Guardar cambios, Retorna INT
        int SaveChanges();
        void SaveChangesTransaction();
    }
}
