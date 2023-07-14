using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoreBanco.Clases
{
    public class Cuenta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public decimal Saldo { get; set; }
        public int TipoId { get; set; }
        public string NumeroCuenta { get; set; }
    }
    public class Transaccion
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public int CuentaId { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string NumeroTransaccion { get; set; }
    }
}