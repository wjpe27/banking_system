using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CoreBanco
{
    /// <summary>
    /// Descripción breve de General
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class General : System.Web.Services.WebService
    {
        Connection con = new Connection();
        string ValidApiKey = "123SARSAno12nio";

        [WebMethod]
        public DataTable SelectTable(string tableName, string orderByColumn, string apiKey)
        {
            // Verificar API Key
            if (apiKey != ValidApiKey)
            {
                // API Key inválida
                throw new Exception("Invalid API Key");
            }

            // Crear la consulta SQL
            string query = "SELECT * FROM " + tableName + " ORDER BY " + orderByColumn;

            // Ejecutar la consulta SQL y almacenar el resultado en un DataTable
            SqlCommand cmd = new SqlCommand(query, con.connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Retornar el DataTable
            return dt;
        }
    }
}

