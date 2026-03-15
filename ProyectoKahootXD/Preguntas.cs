using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoKahootXD.Conexion;

namespace ProyectoKahootXD
{
    internal class Preguntas
    {
        int numPrin = 0;
        string enunPrin = "";
        string tipoPrin = "";
        int idPrin = 0;

        Conexion conexion = new Conexion();

        public void getpregunta(int categoria)
        {

            MySqlConnection con = conexion.getConexion();

            string query = "SELECT numero_pregunta, id, enunciado From preguntas WHERE categoria_id = " + categoria.ToString() + " ORDER BY rand() LIMIT 1;";

            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                numPrin = reader.GetInt32("numero_pregunta");
                idPrin = reader.GetInt32("id");
                enunPrin = reader.GetString("enunciado");
                tipoPrin = reader.GetString("tipo_respuesta");
            }


            conexion.desconexion();
            reader.Close();
        }
    }
}
      
