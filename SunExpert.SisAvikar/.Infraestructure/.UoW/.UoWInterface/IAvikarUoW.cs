using SunExpert.Framework.DataUoWInterface;
using System;

namespace SunExpert.SisAvikar.RepositoryInterface
{
    //Interface IAvikarUoW extiende de IDisposable AND IUoWDev
    public interface IAvikarUoW: IUoWDev, IDisposable
    {
        //Creamos
        IAvikarRepository AvikarRepository { get; }
    }
}
