namespace Domain.Entities
{
    public class Cuenta
    {
        public int? Id { set; get; }
        public string NumeroCuenta { set; get; }
        public int? TipoCuentaId { set; get; }
        public decimal? Saldo { set; get; }
        public int? EstadoId { set; get; }
        public int? IdCliente { set; get; }
    }
}
