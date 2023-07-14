using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CajaBanco
{

    public class Conexion
    {
        public SqlConnection connection;
        public Conexion()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Randy\\source\\repos\\CajaBanco\\CajaBanco\\CajaBD.mdf;Integrated Security=True";
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

        public static bool IsInternetConnectionActive()
        {
            try
            {
                string host = "www.google.com";
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(host);

                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
    public class GestorBaseDeDatos
    {
        CoreGeneral.GeneralSoapClient general = new CoreGeneral.GeneralSoapClient();    
        Conexion Conexion = new Conexion();
        public void LlamarCloner()
        {

            if (Conexion.IsInternetConnectionActive())
            {
                string[] Tablas = new string[] { "Billetes","Clientes" };
                for (int i = 0; i < Tablas.Length; i++)
                {
                    GestorBaseDeDatos gestorBaseDeDatos = new GestorBaseDeDatos();
                    List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
                    results = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(general.Cloner("1234", Tablas[i]));
                    gestorBaseDeDatos.ElCloner(results, "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Francisco\\Downloads\\CajaBanco\\CajaBanco\\CajaBD.mdf;Integrated Security=True", Tablas[i]);
                }
            }

        }
        public void ElCloner(List<Dictionary<string, object>> data, string localConnectionString, string tableName)
        {
            // Definir la cadena de conexión a la base de datos local
            SqlConnection localConnection = new SqlConnection(localConnectionString);
            localConnection.Open();

            // Obtener la lista de tablas en la base de datos de Azure

            // Obtener la lista de columnas para la tabla actual
            string columnsQuery = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
            SqlCommand columnsCommand = new SqlCommand(columnsQuery, localConnection);
            SqlDataReader columnsReader = columnsCommand.ExecuteReader();
            List<string> columns = new List<string>();
            while (columnsReader.Read())
            {
                columns.Add(columnsReader[0].ToString());
            }
            columnsReader.Close();

            // Crear la consulta SQL para insertar o actualizar los datos en la tabla local
            string insertQuery = "MERGE " + tableName + " AS Target " +
                "USING (SELECT " + string.Join(", ", columns.Select(c => "@" + c)) + ") AS Source (" + string.Join(", ", columns) + ") " +
                "ON (" + string.Join(" AND ", columns.Select(c => "Target." + c + " = Source." + c)) + ") " +
                "WHEN MATCHED THEN " +
                "UPDATE SET " + string.Join(", ", columns.Select(c => "Target." + c + " = Source." + c)) + " " +
                "WHEN NOT MATCHED THEN " +
                "INSERT (" + string.Join(", ", columns) + ") VALUES (" + string.Join(", ", columns.Select(c => "Source." + c)) + ");";
            SqlCommand insertCommand = new SqlCommand(insertQuery, localConnection);

            // Recorrer los diccionarios devueltos por el servicio web y ejecutar la consulta INSERT para cada uno
            foreach (Dictionary<string, object> record in data)
            {
                // Asignar valores a los parámetros de la consulta INSERT
                // (los valores deben coincidir con el orden y el tipo de las columnas en la tabla local)
                foreach (string column in columns)
                {
                    object value;
                    if (record.TryGetValue(column, out value))
                    {
                        if (!insertCommand.Parameters.Contains("@" + column))
                        {
                            insertCommand.Parameters.AddWithValue("@" + column, value ?? DBNull.Value);
                        }
                        else
                        {
                            insertCommand.Parameters["@" + column].Value = value ?? DBNull.Value;
                        }
                    }
                    else
                    {
                        if (!insertCommand.Parameters.Contains("@" + column))
                        {
                            insertCommand.Parameters.AddWithValue("@" + column, DBNull.Value);
                        }
                        else
                        {
                            insertCommand.Parameters["@" + column].Value = DBNull.Value;
                        }
                    }
                }

                if (VerificarInser(insertCommand, tableName))
                {
                    object idValue = insertCommand.Parameters["@" + "Id"].Value;
                    string query = "DELETE FROM " + tableName + " WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, insertCommand.Connection);
                    command.Parameters.AddWithValue("@Id", idValue);
                    command.ExecuteNonQuery();
                    insertCommand.ExecuteNonQuery();
                }
                else
                {
                    insertCommand.ExecuteNonQuery();
                }

            }


            localConnection.Close();
        }
        private bool VerificarInser(SqlCommand insertCommand, string tablename)
        {
            bool idExists = false;
            string idColumnName = "Id"; // reemplazar por el nombre real de la columna de ID en la tabla
            object idValue = insertCommand.Parameters["@" + idColumnName].Value;

            // Consultar si la ID ya existe en la tabla
            string selectQuery = "SELECT COUNT(*) FROM " + tablename + " WHERE " + idColumnName + " = @ID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, insertCommand.Connection);
            selectCommand.Parameters.AddWithValue("@ID", idValue);
            int count = (int)selectCommand.ExecuteScalar();

            if (count > 0)
            {
                idExists = true;
            }

            return idExists;
        }





    }
}
