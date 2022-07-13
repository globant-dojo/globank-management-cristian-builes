using System;

namespace Domain.Entities
{
    public class Movimiento
    {
        public int? Id { set; get; }
        public DateTime? Fecha { set; get; }
        public int? TipoMovimientoId { set; get; }
        public decimal? Valor { set; get; }
        public decimal? Saldo { set; get; }
        public int? CuentaId { set; get; }
    }
}
