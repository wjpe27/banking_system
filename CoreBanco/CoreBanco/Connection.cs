using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Diagnostics;
using System.Reflection;
using FireSharp.Response;

namespace CoreBanco
{

    public class Connection
    {

        public IFirebaseConfig Conexion = new FirebaseConfig
        {
            AuthSecret = "3YkgY0A9A0w0baHL5q7voSjkESTeKhrSXwjLtvrL",
            BasePath = "https://bdlogs-2390b-default-rtdb.firebaseio.com/logs"
        };
        public IFirebaseClient client = null;


        public SqlConnection connection;
        public Connection()
        {
            string connectionString = "Data Source=software1106084.database.windows.net;Initial Catalog=BDBanco;Persist Security Info=True;User ID=FRANCISCO;Password=9Kg91649E";
            connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }


        public void RegistroHistorico(LOG lOG, int origen)
        {
            try
            {
                string fechaHora = DateTime.Now.ToString("dd-MM-yyyy/HH/mm/ss/FFF-ffff-fffff");
                client = new FireSharp.FirebaseClient(Conexion);

                // Rutas de ubicación en la base de datos
                Dictionary<int, string> rutas = new Dictionary<int, string>()
        {
            { 1, "RegistroHistorico/Web/Core" },
            { 2, "RegistroHistorico/Caja/Core" }
        };

                // Verifica si la ruta de ubicación está definida
                if (!rutas.TryGetValue(origen, out string rutaBase))
                {
                    throw new ArgumentException($"Origen no válido: {origen}");
                }

                // Determina si es un registro de éxito o de error
                string rutaTipo = (lOG.Tipo == 1) ? "Exito" : "Errores";

                // Ruta completa de ubicación en la base de datos
                string ruta = $"{rutaBase}/{rutaTipo}/{lOG.Remitente}/{fechaHora}";

                // Establece el registro histórico en la base de datos
                FirebaseResponse respuesta = client.Set(ruta, lOG);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
            }
        }

    }

    public class LOG
    {
        public string Remitente { get; set; }
        public string Metodo { get; }
        public DateTime FechaYHora { get; }
        public string Resultado { get; set; }
        public string TipoDeRetono { get; }

        public int Tipo { get; set; }

        public LOG()
        {
            // Obtener la información del método actual
            MethodBase metodoBase = new StackTrace().GetFrame(1).GetMethod();
            Metodo = $"{metodoBase.DeclaringType}.{metodoBase.Name}";
            TipoDeRetono = metodoBase.ReflectedType.Name;
            // Establecer la fecha y hora actual
            FechaYHora = DateTime.Now;
        }
    }
}