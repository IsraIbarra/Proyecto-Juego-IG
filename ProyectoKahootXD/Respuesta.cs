using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKahootXD
{
    internal class Respuesta
    {
        string resp_A = "";
        int respID_A = 0;
        string resp_B = "";
        int respID_B = 0;
        string resp_C = "";
        int respID_C = 0;
        string resp_D = "";
        int respID_D = 0;
        int respID_correcta = 0;

        Conexion conexion = new Conexion();
        
        public void getRespuestas(int idPregunta)
        {
            string query = "SELECT id, letra, contenido, correcta FROM opciones WHERE pregunta_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conexion.getConexion());
            cmd.Parameters.AddWithValue("@id", idPregunta);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string letra = reader.GetString("letra");

                if (letra == "a")
                {
                    respID_A = reader.GetInt32("id");
                    resp_A = reader.GetString("contenido");
                }
                else if (letra == "b")
                {
                    respID_B = reader.GetInt32("id");
                    resp_B = reader.GetString("contenido");
                }
                else if (letra == "c")
                {
                    respID_C = reader.GetInt32("id");
                    resp_C = reader.GetString("contenido");
                }
                else if (letra == "d")
                {
                    respID_D = reader.GetInt32("id");
                    resp_D = reader.GetString("contenido");
                }

                if (reader.GetInt32("correcta") == 1)
                {
                    respID_correcta = reader.GetInt32("id");
                }
            }

            reader.Close();
            conexion.desconexion();
        }
    }
}
