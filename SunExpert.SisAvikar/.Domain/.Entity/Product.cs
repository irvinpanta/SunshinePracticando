namespace SunExpert.SisAvikar.Domain.Entity
{
    public class Product
    {
        public int ProId { get; set; }
        public string ProDescripcion { get; set; }
        public int ProStock { get; set; }
        public decimal ProPrecio { get; set; }
        public byte ProActivo { get; set; }
        public int FamProId { get; set; }
    }
}
