using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using static CoreBanco.Transferencias;

namespace CoreBanco
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class Clientes : System.Web.Services.WebService
    {
        private Connection con = new Connection();
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();

        [WebMethod]
        public bool CrearClientes(string nombre, string dir, string tel, string correo, string apellido, string cedula,string Remitente = "Anonimo", int Origen = 1)
        {
            bool x = false;
            int tipo = 1;
            string result = "";

            try
            {

                SqlCommand spInsertarCliente = new SqlCommand("InsertarCliente", con.connection);
                
                con.OpenConnection();   

                spInsertarCliente.CommandType = CommandType.StoredProcedure;

                spInsertarCliente.Parameters.AddWithValue("@nombre", nombre);
                spInsertarCliente.Parameters.AddWithValue("@direccion", dir);
                spInsertarCliente.Parameters.AddWithValue("@telefono", tel);
                spInsertarCliente.Parameters.AddWithValue("@correo", correo);
                spInsertarCliente.Parameters.AddWithValue("@apellido", apellido);
                spInsertarCliente.Parameters.AddWithValue("@cedula", cedula);

                int rowsAffected = spInsertarCliente.ExecuteNonQuery();


                if (rowsAffected > 0)
                {

                     x = true;

                }

                result = x.ToString();
                return x;

            }
            catch (Exception ex)
            {
                result= ex.Message;
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
        public bool EliminarCliente(string cedula, string Remitente = "Anonimo", int Origen = 1)
        {
            bool x = false;
            int tipo = 1;
            string result = "";

            try
            {
                SqlCommand spEliminarCliente = new SqlCommand("EliminarCliente", con.connection);

                con.OpenConnection();

                spEliminarCliente.CommandType = CommandType.StoredProcedure;

                spEliminarCliente.Parameters.AddWithValue("@cedula", cedula);

                int rowsAffected = spEliminarCliente.ExecuteNonQuery();

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
                lOG.Remitente = Remitente;
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, Origen);

                con.CloseConnection();
            }
        }

        [WebMethod]
        public DataSet MostrarCliente(string nombre = "", string Remitente = "Anonimo", int Origen = 1)
        {
            int tipo = 1;
            string result = "";

            try
            {
                SqlCommand spMostrarCliente = new SqlCommand("MostrarCliente", con.connection);

                con.OpenConnection();

                spMostrarCliente.CommandType = CommandType.StoredProcedure;

                spMostrarCliente.Parameters.AddWithValue("@nombre", nombre);

                SqlDataAdapter adapter = new SqlDataAdapter(spMostrarCliente);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                result = "Consulta exitosa";
                return ds;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                tipo = 2;
                return null;
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
        public bool CrearCuentaCliente(int cliente_id, int tipo_id, decimal saldo = 0)
        {
            bool x = false;
            int tipo = 1;
            string result = "";

            try
            {
                string numero_cuenta = GenerarNumeroCuenta();

                SqlCommand spCrearCuentaCliente = new SqlCommand("CrearCuentaCliente", con.connection);
                con.OpenConnection();

                spCrearCuentaCliente.CommandType = CommandType.StoredProcedure;

                spCrearCuentaCliente.Parameters.AddWithValue("@cliente_id", cliente_id);
                spCrearCuentaCliente.Parameters.AddWithValue("@saldo", saldo);
                spCrearCuentaCliente.Parameters.AddWithValue("@tipo_id", tipo_id);
                spCrearCuentaCliente.Parameters.AddWithValue("@numero_cuenta", numero_cuenta);

                int rowsAffected = spCrearCuentaCliente.ExecuteNonQuery();

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
                lOG.Remitente = "Anonimo";
                lOG.Tipo = tipo;
                con.RegistroHistorico(lOG, 1);

                con.CloseConnection();
            }
        }

        [WebMethod]
        private static string GenerarNumeroCuenta()
        {


            lock (syncLock)
            {
                int numeroAleatorio = random.Next(10000000, 99999999);
                return numeroAleatorio.ToString().PadLeft(10, '0');
            }
        }

        [WebMethod]
        public List<CoreBanco.Clases.Cuenta> MostrarCuentasCliente(string cedula)
        {
            List<CoreBanco.Clases.Cuenta> cuentas = new List<CoreBanco.Clases.Cuenta>();

            try
            {
                // Buscar el ID del cliente en la tabla de Clientes
                int clienteId = 0;
                SqlCommand cmdBuscarCliente = new SqlCommand("SELECT id FROM Clientes WHERE cedula = @cedula", con.connection);
                cmdBuscarCliente.Parameters.AddWithValue("@cedula", cedula);
                con.OpenConnection();
                SqlDataReader readerCliente = cmdBuscarCliente.ExecuteReader();

                if (readerCliente.Read())
                {
                    clienteId = Convert.ToInt32(readerCliente["id"]);
                }

                readerCliente.Close();

                if (clienteId > 0)
                {
                    // Buscar todas las cuentas asociadas al ID del cliente en la tabla de Cuentas
                    SqlCommand cmdBuscarCuentas = new SqlCommand("SELECT id, cliente_id, empleado_id, saldo, tipo_id, numero_cuenta FROM Cuentas WHERE cliente_id = @clienteId", con.connection);
                    cmdBuscarCuentas.Parameters.AddWithValue("@clienteId", clienteId);

                    SqlDataReader readerCuentas = cmdBuscarCuentas.ExecuteReader();

                    while (readerCuentas.Read())
                    {
                        CoreBanco.Clases.Cuenta cuenta = new CoreBanco.Clases.Cuenta();
                        cuenta.Id = Convert.ToInt32(readerCuentas["id"]);
                        cuenta.ClienteId = Convert.ToInt32(readerCuentas["cliente_id"]);
                        cuenta.Saldo = Convert.ToDecimal(readerCuentas["saldo"]);
                        cuenta.TipoId = Convert.ToInt32(readerCuentas["tipo_id"]);
                        cuenta.NumeroCuenta = readerCuentas["numero_cuenta"].ToString();

                        cuentas.Add(cuenta);
                    }

                    readerCuentas.Close();
                }

                return cuentas;
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario
                return new List<CoreBanco.Clases.Cuenta>();
            }
            finally
            {
                con.CloseConnection();
            }
        }

        [WebMethod]
        public bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, decimal cantidad, decimal tasa_interes, int plazo_meses, string Remitente = "Anonimo", int Origen = 1)
        {
            bool success = false;
            string result = "";
            int tipo = 1;

            try
            {
                SqlCommand spCrearPrestamo = new SqlCommand("CrearPrestamo", con.connection);
                con.OpenConnection();
                spCrearPrestamo.CommandType = CommandType.StoredProcedure;

                spCrearPrestamo.Parameters.AddWithValue("@cliente_id", cliente_id);
                spCrearPrestamo.Parameters.AddWithValue("@fecha_inicio", fecha_inicio);
                spCrearPrestamo.Parameters.AddWithValue("@cantidad", cantidad);
                spCrearPrestamo.Parameters.AddWithValue("@tasa_interes", tasa_interes);
                spCrearPrestamo.Parameters.AddWithValue("@plazo_meses", plazo_meses);

                int rowsAffected = spCrearPrestamo.ExecuteNonQuery();

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
        public bool RevisarContraseña(string correo, string contraseña, string remitente = "Anonimo", int origen = 1)
        {
            bool x = false;
            int tipo = 1;
            string result = "";

            try
            {
                SqlCommand spRevisarContraseña = new SqlCommand("VerificarContrasena", con.connection);
                con.OpenConnection();

                spRevisarContraseña.CommandType = CommandType.StoredProcedure;

                spRevisarContraseña.Parameters.AddWithValue("@correo", correo);
                spRevisarContraseña.Parameters.AddWithValue("@contraseña", contraseña);

                int rowsAffected = (int)spRevisarContraseña.ExecuteScalar();

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
    }
}
