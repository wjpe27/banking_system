using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CoreBanco.Clases;

namespace CoreBanco
{
    /// <summary>
    /// Descripción breve de Transferencias
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Transferencias : System.Web.Services.WebService
    {
        private Connection con = new Connection();

        [WebMethod]
        public bool Deposito(string numeroCuenta, decimal cantidad, string descripcion = "Deposito", string remitente = "Anonimo", int origen = 1)
        {
            bool x = false;
            int tipo = 1;
            string result = "";

            try
            {
                SqlCommand spDeposito = new SqlCommand("Deposito", con.connection);
                con.OpenConnection();

                spDeposito.CommandType = CommandType.StoredProcedure;

                spDeposito.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
                spDeposito.Parameters.AddWithValue("@cantidad", cantidad);
                spDeposito.Parameters.AddWithValue("@descripcion", descripcion);

                int rowsAffected = spDeposito.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    x = true;
                }

                result = x.ToString();
                return x;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return false;
            }
            finally
            {
                LOG lOG = new LOG();
                lOG.Resultado = result;
                lOG.Remitente = remitente;
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, origen);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public bool Transferir(string numeroCuentaOrigen, string numeroCuentaDestino, decimal monto, string Remitente = "Anonimo", int Origen = 1)
        {
            bool transferenciaExitosa = false;
            int tipo = 1;
            string result = "";

            try
            {
                // Genera un número de transacción aleatorio
                Random random = new Random();
                int numeroTransaccion = random.Next(1000000000, int.MaxValue);

                SqlCommand spTransferirDinero = new SqlCommand("TransferirDinero", con.connection);
                con.OpenConnection();

                // Transferir dinero entre cuentas
                spTransferirDinero.CommandType = CommandType.StoredProcedure;
                spTransferirDinero.Parameters.AddWithValue("@numeroCuentaOrigen", numeroCuentaOrigen);
                spTransferirDinero.Parameters.AddWithValue("@numeroCuentaDestino", numeroCuentaDestino);
                spTransferirDinero.Parameters.AddWithValue("@cantidad", monto);
                spTransferirDinero.Parameters.AddWithValue("@numeroTransaccion", numeroTransaccion);
                int filasAfectadas = spTransferirDinero.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    transferenciaExitosa = true;
                }

                result = transferenciaExitosa.ToString();
                return transferenciaExitosa;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return false;
            }
            finally
            {
                LOG lOG = new LOG();
                lOG.Resultado = result;
                lOG.Remitente = Remitente;
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, Origen);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public bool RetirarDinero(string numeroCuenta, decimal monto)
        {
            bool retiroExitoso = false;
            int tipo = 1;
            string result = "";

            try
            {
                // Genera un número de transacción aleatorio
                Random random = new Random();
                int numeroTransaccion = random.Next(1000000000, int.MaxValue);

                SqlCommand spRetirarDinero = new SqlCommand("RetirarDineroPorNumeroCuenta", con.connection);
                con.OpenConnection();

                spRetirarDinero.CommandType = CommandType.StoredProcedure;
                spRetirarDinero.Parameters.AddWithValue("@numeroCuenta", numeroCuenta);
                spRetirarDinero.Parameters.AddWithValue("@cantidad", monto);
                spRetirarDinero.Parameters.AddWithValue("@numeroTransaccion", numeroTransaccion);

                int rowsAffected = spRetirarDinero.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    retiroExitoso = true;
                }

                result = retiroExitoso.ToString();
                return retiroExitoso;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return false;
            }
            finally
            {
                LOG lOG = new LOG();
                lOG.Resultado = result;
                lOG.Remitente = "Anonimo";
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, 1);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public List<Transaccion> MostrarTransacciones()
        {
            List<Transaccion> transacciones = new List<Transaccion>();

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Transacciones", con.connection);
                con.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Transaccion transaccion = new Transaccion();
                    transaccion.Id = Convert.ToInt32(reader["id"]);
                    transaccion.FechaHora = Convert.ToDateTime(reader["fecha_hora"]);
                    transaccion.CuentaId = Convert.ToInt32(reader["cuenta_id"]);
                    transaccion.Cantidad = Convert.ToDecimal(reader["cantidad"]);
                    transaccion.Descripcion = reader["descripcion"].ToString();
                    transaccion.NumeroTransaccion = reader["numero_transaccion"].ToString();

                    transacciones.Add(transaccion);
                }

                reader.Close();
                return transacciones;
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario
                return null;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        [WebMethod]
        public int InsertarTurnoConBilletes(int empleado_id, DateTime fecha, DateTime hora_inicio, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {
            int turno_id = 0;
            string result = "";
            int tipo = 1;

            try
            {
                SqlCommand spInsertarTurnoConBilletes = new SqlCommand("InsertarTurnoConBilletes", con.connection);
                con.OpenConnection();
                spInsertarTurnoConBilletes.CommandType = CommandType.StoredProcedure;

                spInsertarTurnoConBilletes.Parameters.AddWithValue("@empleado_id", empleado_id);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@fecha", fecha);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@hora_inicio", hora_inicio);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion1", denominacion1);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion5", denominacion5);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion10", denominacion10);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion25", denominacion25);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion50", denominacion50);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion100", denominacion100);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion200", denominacion200);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion500", denominacion500);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion1000", denominacion1000);
                spInsertarTurnoConBilletes.Parameters.AddWithValue("@denominacion2000", denominacion2000);

                SqlDataReader reader = spInsertarTurnoConBilletes.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        turno_id = reader.GetInt32(0);
                    }
                }

                result = turno_id.ToString();
                return turno_id;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return 0;
            }
            finally
            {
                LOG lOG = new LOG();
                lOG.Resultado = result;
                lOG.Remitente = Remitente;
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, Origen);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, DateTime fecha_fin, DateTime dia_corte_pago, decimal sueldo_restante, decimal tasa_interes)
        {
            bool result = false;

            try
            {
                
                {
                    using (SqlCommand cmd = new SqlCommand("CrearPrestamo", con.connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@cliente_id", cliente_id);
                        cmd.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                        cmd.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        cmd.Parameters.AddWithValue("@dia_corte_pago", dia_corte_pago);
                        cmd.Parameters.AddWithValue("@sueldo_restante", sueldo_restante);
                        cmd.Parameters.AddWithValue("@tasa_interes", tasa_interes);

                        con.OpenConnection();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario, como escribir en un archivo de registro o mostrar un mensaje de error
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            return result;
        }

        [WebMethod]
        public bool TerminarTurno(int turno_id, DateTime hora_fin, int denominacion1, int denominacion5, int denominacion10, int denominacion25, int denominacion50, int denominacion100, int denominacion200, int denominacion500, int denominacion1000, int denominacion2000, string Remitente = "Anonimo", int Origen = 1)
        {
            bool success = false;
            string result = "";
            int tipo = 1;

            try
            {
                SqlCommand spTerminarTurno = new SqlCommand("TerminarTurno", con.connection);
                con.OpenConnection();
                spTerminarTurno.CommandType = CommandType.StoredProcedure;

                spTerminarTurno.Parameters.AddWithValue("@turno_id", turno_id);
                spTerminarTurno.Parameters.AddWithValue("@hora_fin", hora_fin);
                spTerminarTurno.Parameters.AddWithValue("@denominacion1", denominacion1);
                spTerminarTurno.Parameters.AddWithValue("@denominacion5", denominacion5);
                spTerminarTurno.Parameters.AddWithValue("@denominacion10", denominacion10);
                spTerminarTurno.Parameters.AddWithValue("@denominacion25", denominacion25);
                spTerminarTurno.Parameters.AddWithValue("@denominacion50", denominacion50);
                spTerminarTurno.Parameters.AddWithValue("@denominacion100", denominacion100);
                spTerminarTurno.Parameters.AddWithValue("@denominacion200", denominacion200);
                spTerminarTurno.Parameters.AddWithValue("@denominacion500", denominacion500);
                spTerminarTurno.Parameters.AddWithValue("@denominacion1000", denominacion1000);
                spTerminarTurno.Parameters.AddWithValue("@denominacion2000", denominacion2000);

                int rowsAffected = spTerminarTurno.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    success = true;
                }

                result = success.ToString();
                return success;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return false;
            }
            finally
            {
                LOG lOG = new LOG();
                lOG.Resultado = result;
                lOG.Remitente = Remitente;
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, Origen);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public bool PagoPrestamo(int prestamo_id, decimal monto_pago, string remitente = "Anonimo", int origen = 1)
        {
            bool resultado = false;
            int tipo = 1;
            string logResultado = "";

            try
            {

                {
                    using (SqlCommand cmd = new SqlCommand("PagoPrestamo", con.connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@prestamo_id", prestamo_id);
                        cmd.Parameters.AddWithValue("@monto_pago", monto_pago);

                        con.OpenConnection();
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logResultado = ex.Message;
                tipo = 2;
                // Aquí puedes manejar el error
            }
            finally
            {
                LOG log = new LOG();
                log.Resultado = resultado ? "Pago realizado exitosamente" : logResultado;
                log.Remitente = remitente;
                log.Tipo = tipo;
                con.RegistroHistorico(log, origen);
            }

            return resultado;
        }
    }


}


