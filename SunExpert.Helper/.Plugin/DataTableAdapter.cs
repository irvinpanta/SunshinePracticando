namespace SunExpert.Helper.Plugin
{
    public class DataTableAdapter
    {
        /// <summary>
        /// Representa el número de veces que se ha realizado una petición.
        /// </summary>
        public int draw { get; set; }
        /// <summary>
        /// Total de registros antes de filtrar.
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// Total de registros ya filtrados.
        /// </summary>
        public int recordsFiltered { get; set; }
        /// <summary>
        /// Arreglo de datos que se va a mostrar en la tabla.
        /// </summary>
        public dynamic data { get; set; }
        /// <summary>
        /// Parámetro opcional y nos permite mandar mensajes de error que hayan pasado del lado del servidor.
        /// </summary>
        public string error { get; set; }
        public DataTableAdapter() { }
        public DataTableAdapter(int draw, dynamic data, int recordTotal)
        {
            this.draw = draw;
            this.data = data;
            this.recordsFiltered = 0;
            this.recordsTotal = recordTotal;
            error = "";
            if (data != null)
                this.recordsFiltered = recordTotal; //Enumerable.Count(recordTotal);
        }
    }
}
