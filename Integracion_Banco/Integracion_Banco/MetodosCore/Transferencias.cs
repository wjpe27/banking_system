using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracion_Banco.MetodosCore
{

    public class Transferencias
    {
        ServiceTransferencias.TransferenciasSoapClient Servicio = new ServiceTransferencias.TransferenciasSoapClient();


        public int InsertarTurnoConBilletes(int empleado_id, DateTime fecha, DateTime hora_fin, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {

            try
            {
                return Servicio.InsertarTurnoConBilletes(empleado_id, fecha, hora_fin, denominacion1, denominacion5, denominacion10, denominacion25, denominacion50, denominacion100, denominacion200, denominacion500, denominacion1000, denominacion2000, Remitente, Origen);
            }
            catch (Exception)
            {

                return 1;
            }
        }
        public bool TerminarTurno(int turno_id, DateTime hora_fin, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {

            try
            {
                return Servicio.TerminarTurno(turno_id, hora_fin, denominacion1, denominacion5, denominacion10, denominacion25, denominacion50, denominacion100, denominacion200, denominacion500, denominacion1000, denominacion2000, Remitente, Origen);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, DateTime fecha_fin, DateTime dia_corte_pago, decimal sueldo_restante, decimal tasa_interes)
        {
            try
            {
                return Servicio.CrearPrestamo(cliente_id, fecha_inicio, fecha_fin, dia_corte_pago, sueldo_restante, tasa_interes);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool PagoPrestamo(int prestamo_id, decimal monto_pago, string remitente = "Anonimo", int origen = 1)
        {
            try
            {
                return Servicio.PagoPrestamo(prestamo_id, monto_pago, remitente, origen);
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Deposito(string numeroCuenta, decimal cantidad, string descripcion = "Deposito", string remitente = "Anonimo", int origen = 1)
        {
            try
            {
                return Servicio.Deposito(numeroCuenta, cantidad, descripcion, remitente, origen);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Transferir(string numeroCuentaOrigen, string numeroCuentaDestino, decimal monto, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return Servicio.Transferir(numeroCuentaOrigen, numeroCuentaDestino, monto, Remitente, Origen);
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool RetirarDinero(string numeroCuenta, decimal monto)
        {
            try
            {
                return Servicio.RetirarDinero(numeroCuenta, monto);
            }
            catch (Exception)
            {

                return false;
            }

        }
        public ServiceTransferencias.Transaccion[] MostrarTransacciones()
        {
            try
           {
               return Servicio.MostrarTransacciones();
           }
            catch (Exception)
            {

               throw;
            }
        }
    }
}