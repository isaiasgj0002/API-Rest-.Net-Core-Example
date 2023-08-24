namespace miprimerwebapi.Models
{
    public class Product
    {
        public int Id{ get; set; }
        public string Nombre{ get; set; }
        public string Descripcion{ get; set; }
        public decimal Precio{ get; set; }
        public DateTime FechaAlta{ get; set; }
        public bool Activo{ get; set; }
    }
}