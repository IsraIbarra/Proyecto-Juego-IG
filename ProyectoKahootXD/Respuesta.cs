using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            MySqlConnection con = conexion.getConexion();
            string query = "SELECT id, letra, contenido, correcta FROM opciones WHERE pregunta_id = " + idPregunta;

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                respID_A = reader.GetInt32("id");
                resp_A = reader.GetString("contenido");
                if( reader.GetInt32("correcta") == 1)
                {
                    respID_correcta = reader.GetInt32("id");
                } //seguir aqui 
            }

        }




    }
}
