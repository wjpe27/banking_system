using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Integracion_Banco.ConexionCaja
{
    /// <summary>
    /// Descripción breve de Clientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    
    public class Clientes : System.Web.Services.WebService
    {
        MetodosCore.CuentaCliente clientes = new MetodosCore.CuentaCliente();

        [WebMethod]
        public bool CrearClientes(string nombre, string dir, string tel, string correo, string apellido, string cedula, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientes.CrearClientes(nombre, dir, tel, correo, apellido, cedula, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public bool EliminarCliente(string cedula, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientes.EliminarCliente(cedula, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public DataSet MostrarCliente(string nombre = "", string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientes.MostrarCliente(nombre, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool CrearCuentaCliente(int cliente_id, int tipo_id, decimal saldo = 0)
        {
            try
            {
                return clientes.CrearCuentaCliente(cliente_id, tipo_id, saldo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public ServiceClientes.Cuenta[] MostrarCuentasCliente(string cedula)
        {
            try
            {
                return clientes.MostrarCuentasCliente(cedula);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod]
        public bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, decimal cantidad, decimal tasa_interes, int plazo_meses, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientes.CrearPrestamo(cliente_id, fecha_inicio, cantidad, tasa_interes, plazo_meses, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public bool RevisarContraseña(string correo, string contraseña, string remitente = "Anonimo", int origen = 1)
        {
            try
            {
                return clientes.RevisarContraseña(correo, contraseña, remitente, origen);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
