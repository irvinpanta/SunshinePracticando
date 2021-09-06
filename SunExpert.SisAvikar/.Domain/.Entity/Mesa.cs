using System;

namespace SunExpert.SisAvikar.Domain.Entity
{
    public class Mesa
    {
        public int xFlag { get; set; }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte Activo { get; set; }
        public DateTime FecSistema { get; set; }
        public int Salon { get; set; }
        public byte MesaRapida { get; set; }
    }
}
