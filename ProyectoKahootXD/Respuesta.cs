using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoKahootXD
{
    public class Respuesta
    {
        public string resp_A = "";
        public int respID_A = 0;
        public string resp_B = "";
        public int respID_B = 0;
        public string resp_C = "";
        public int respID_C = 0;
        public string resp_D = "";
        public int respID_D = 0;
        public int respID_correcta = 0;

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