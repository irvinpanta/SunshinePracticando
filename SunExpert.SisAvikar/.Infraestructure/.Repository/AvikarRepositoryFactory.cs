using SunExpert.Framework.DataContext;
using SunExpert.SisAvikar.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.SisAvikar.Repository.Repository
{
    public static class AvikarRepositoryFactory
    {
        public static IAvikarRepository DinningHallRepository(IContextDbContext db)
        {
            return new AvikarRepository(db);
        }
    }
}
