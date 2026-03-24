using MySql.Data.MySqlClient;
//using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKahootXD
{
    internal class Conexion
    {
        private MySqlConnection conexion;
        private string server = "localhost";
        private string database = "trivia";
        private string user = "root";
        private string password = "root";
        private string cadenaConexion;
        
    

    public Conexion()
        {
            cadenaConexion = "Database=" + database +
                         "; DataSource=" + server +
                         "; User Id=" + user +
                         "; Password=" + password;
        }
     
    public MySqlConnection getConexion()
        {
            conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }

        public void desconexion()
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }




    }





}