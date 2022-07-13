namespace Domain.Entities
{
    public class Cliente : Persona
    {
        public string Clave { set; get; }
        public int? EstadoId { set; get; }
    }
}
