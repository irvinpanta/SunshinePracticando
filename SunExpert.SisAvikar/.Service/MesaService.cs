using SunExpert.SisAvikar.Domain.Customize;
using SunExpert.SisAvikar.Domain.Entity;
using SunExpert.SisAvikar.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunExpert.SisAvikar.Service
{
    public partial class AvikarService
    {
        public List<MesaCE> MesaList()
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try
                {

                    return uow.AvikarRepository.MesaList();

                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
        }

        //Metodo para Guardar/Modificar
        public int MesaSave(Mesa obj)
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try
                {
                    //Si El Id recibido es O, se procede a Grabar
                    if (obj.Id == 0)
                    {
                        uow.Add<Mesa>(obj);
                        uow.SaveChangesTransaction();
                    }
                    else
                    { //Sino se procede a Modificar
                        uow.Attach<Mesa>(obj);
                        uow.SaveChangesTransaction();
                    }
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
            return 1;
        }
    }
}
