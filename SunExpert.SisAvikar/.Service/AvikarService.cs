using SunExpert.SisAvikar.Repository.UoW;
using SunExpert.SisAvikar.RepositoryInterface;
using SunExpert.SisAvikar.ServiceInterface;
using System;

namespace SunExpert.SisAvikar.Service
{
    public partial class AvikarService : IAvikarService
    {
        private IAvikarUoW GetUoWInstance()
        {
            return new AvikarUoW();
        }
    }
}
