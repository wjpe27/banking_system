using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Integracion_Banco.MetodosCore
{
    public class CuentaCliente
    {
        ServiceClientes.ClientesSoapClient clientess = new ServiceClientes.ClientesSoapClient();
 
        public bool CrearClientes(string nombre, string dir, string tel, string correo, string apellido, string cedula, string Remitente = "Anonimo", int Origen = 1)
        {
            try 
            {
               return clientess.CrearClientes(nombre, dir, tel, correo, apellido, cedula, Remitente, Origen);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool EliminarCliente(string cedula, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientess.EliminarCliente(cedula, Remitente, Origen); 
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public DataSet MostrarCliente(string nombre = "", string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientess.MostrarCliente(nombre, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool CrearCuentaCliente(int cliente_id, int tipo_id, decimal saldo = 0)
        {
            try
            {
                return clientess.CrearCuentaCliente(cliente_id, tipo_id, saldo);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public ServiceClientes.Cuenta[] MostrarCuentasCliente(string cedula)
        {
            try
            {
                return clientess.MostrarCuentasCliente(cedula);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool CrearPrestamo(int cliente_id, DateTime fecha_inicio, decimal cantidad, decimal tasa_interes, int plazo_meses, string Remitente = "Anonimo", int Origen = 1)
        {
            try
            {
                return clientess.CrearPrestamo(cliente_id, fecha_inicio, cantidad, tasa_interes, plazo_meses, Remitente, Origen);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RevisarContraseña(string correo, string contraseña, string remitente = "Anonimo", int origen = 1)
        {
            try
            {
                return clientess.RevisarContraseña(correo, contraseña, remitente = "Anonimo", origen = 1);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}