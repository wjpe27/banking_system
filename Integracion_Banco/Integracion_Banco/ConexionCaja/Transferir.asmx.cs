using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Integracion_Banco.ConexionCaja
{
    /// <summary>
    /// Descripción breve de Transferir
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Transferir : System.Web.Services.WebService
    {
        MetodosCore.Transferencias trans = new MetodosCore.Transferencias();

        [WebMethod]

        public int InsertarTurnoConBilletes(int empleado_id, DateTime fecha, DateTime hora_fin, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {
          return  trans.InsertarTurnoConBilletes(empleado_id, fecha, hora_fin, denominacion1, denominacion5,denominacion10, denominacion25,  denominacion50, denominacion100, denominacion200,denominacion500,denominacion1000,  denominacion2000,  Remitente = "Anonimo", Origen = 1);
        }
        [WebMethod]
        public bool TerminarTurno(int turno_id, DateTime hora_fin, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {
            return trans.TerminarTurno(turno_id, hora_fin, denominacion1, denominacion5, denominacion10, denominacion25, denominacion50, denominacion100, denominacion200, denominacion500, denominacion1000, denominacion2000, Remitente = "Anonimo", Origen = 1);
        {

        [WebMethod]

        bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, DateTime fecha_fin, DateTime dia_corte_pago, decimal sueldo_restante, decimal tasa_interes)
        {
             return trans.CrearPrestamo(cliente_id, fecha_inicio, fecha_fin, dia_corte_pago, sueldo_restante, tasa_interes);
        }

        [WebMethod]

         bool PagoPrestamo(int prestamo_id, decimal monto_pago, string remitente = "Anonimo", int origen = 1)
        {
                    return trans.PagoPrestamo( prestamo_id, monto_pago, remitente = "Anonimo", origen = 1);
        }

        [WebMethod]

        bool Deposito(string numeroCuenta, decimal cantidad, string descripcion = "Deposito", string remitente = "Anonimo", int origen = 1)
        {
                    return trans.PagoPrestamo(prestamo_id, monto_pago, remitente = "Anonimo", origen = 1);
                }

        [WebMethod]

        bool Transferir(string numeroCuentaOrigen, string numeroCuentaDestino, decimal monto, string Remitente = "Anonimo", int Origen = 1)
        {
                    return trans.PagoPrestamo(prestamo_id, monto_pago, remitente = "Anonimo", origen = 1);
                }

        [WebMethod]

        bool RetirarDinero(string numeroCuenta, decimal monto)
        {
                    return trans.PagoPrestamo(prestamo_id, monto_pago, remitente = "Anonimo", origen = 1);
                }

        [WebMethod]

        ServiceTransferencias.Transaccion[] MostrarTransacciones()
        {
                    return trans.PagoPrestamo(prestamo_id, monto_pago, remitente = "Anonimo", origen = 1);
                }

    }
    }
}
