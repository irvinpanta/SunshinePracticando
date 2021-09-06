using System;
using System.Collections.Generic;

namespace SunExpert.Framework.DataRepositoryInterface
{
    //Interface IRepositoryDev hereda de Interface IDisposable
    public interface IRepositoryDev: IDisposable
    {
        //Metodo Generico para Grabar
        void Add<T>(T entity) where T : class;
        void Add<T>(IEnumerable<T> entities) where T : class;

        //Metodo Generico para Modificar
        void Attach<T>(T entity) where T : class;
        void Attach<T>(IEnumerable<T> entities) where T : class;
    }
}
