namespace Domain.Entities
{
    public class Persona
    {
        public int? Id { get; set; }
        public string Nombre { set; get; }
        public int? GeneroId { set; get; }
        public int? Edad { set; get; }
        public string Identificacion { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
    }
}
