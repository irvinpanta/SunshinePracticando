using SunExpert.SisAvikar.Domain.Customize;
using SunExpert.SisAvikar.Domain.Entity;
using SunExpert.SisAvikar.RepositoryInterface;
using System;
using System.Collections.Generic;

namespace SunExpert.SisAvikar.Service
{
    public partial class AvikarService
    {
        public List<ProductCE> ProductList()
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try
                {

                    return uow.AvikarRepository.ProductList();

                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
        }

        //Metodo para Guardar/Modificar
        public int ProductSave(Product obj)
        {
            using (IAvikarUoW uow = GetUoWInstance())
            {
                try
                {
                    //Si El Id recibido es O, se procede a Grabar
                    if (obj.ProId == 0)
                    {
                        uow.Add<Product>(obj);
                        uow.SaveChangesTransaction();
                    }
                    else
                    { //Sino se procede a Modificar
                        uow.Attach<Product>(obj);
                        uow.SaveChangesTransaction();
                    }
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
            }
            return obj.ProId;
        }
    }
}
