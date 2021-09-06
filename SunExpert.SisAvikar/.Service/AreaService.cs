using SunExpert.SisAvikar.Domain;
using SunExpert.SisAvikar.Domain.Customize;
using SunExpert.SisAvikar.RepositoryInterface;
using SunExpert.SisAvikar.ServiceInterface;
using System;
using System.Collections.Generic;

namespace SunExpert.SisAvikar.Service
{
    public partial class AvikarService
    {
        //Metodo para Listar todas las Areas
        public List<AreaCE> AreaList()
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try{
                
                    return uow.AvikarRepository.AreaList();
                
                }catch (Exception ex){
                    throw ex.GetBaseException();
                }
            }
        }

        //Metodo para Guardar/Modificar
        public int AreaSave(Area obj)
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try{
                    //Si El Id recibido es O, se procede a Grabar
                    if (obj.Id == 0){
                        uow.Add<Area>(obj);
                        uow.SaveChangesTransaction();
                    }else{ //Sino se procede a Modificar
                        uow.Attach<Area>(obj);
                        uow.SaveChangesTransaction();
                    }
                }catch (Exception ex){
                    throw ex.GetBaseException();
                }
            }
            return 1;
        }

        
    }
}
