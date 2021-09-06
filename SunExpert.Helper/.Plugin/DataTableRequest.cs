using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SunExpert.Helper.Plugin
{
    public class DataTableRequest
    {
        public object filter { get; set; }
        /// <summary>
        /// Numero de petición que se está realizando.
        /// </summary>
        public int draw { get; set; }
        public byte? IsLevelAdmin { get; set; }
        /// <summary>
        /// Diccionario con la información de por medio de campo se va a realizar el ordenamiento.
        /// </summary>
        public Dictionary<string, string>[] order { get; set; }
        /// <summary>
        /// Registro a partir de cual se va a iniciar el paginado.
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// Tamaño de la pagina
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// Valor de la búsqueda
        /// </summary>
        /// <summary>
        /// Valor de la búsqueda
        /// </summary>
        public string searchText { get; set; }
        public string orderColumn
        {
            get
            {
                string column = "";
                if (order != null && order.Length > 0)
                {
                    order[0].TryGetValue("column", out column);
                    column = column == "0" ? "" : column;
                }
                return column;
            }
        }
        public string orderDir
        {
            get
            {
                string dir = "";
                if (order != null && order.Length > 0)
                    order[0].TryGetValue("dir", out dir);
                return dir ?? "";
            }
        }
        public void setFilter(Object obj)
        {
            try
            {
                var result = JsonConvert.SerializeObject(obj);
                this.filter = result;
            }
            catch (NullReferenceException)
            {
                throw new Exception("Se esperaba valores en propiedad filter de SCRUD.");

            }
        }
        public T GetFilter<T>()
        {
            try
            {
                var result = JsonConvert.DeserializeObject<T>(filter.ToString());
                return result;
            }
            catch (NullReferenceException)
            {
                throw new Exception("Se esperaba valores en propiedad filter de SCRUD.");

            }
        }
        public void SetFilter(Object obj)
        {
            try
            {
                this.filter = JsonConvert.SerializeObject(obj);
                // return result;
            }
            catch (NullReferenceException)
            {
                throw new Exception("Se esperaba valores en propiedad filter de SCRUD.");

            }
        }
    }
}
