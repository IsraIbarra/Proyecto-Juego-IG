using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoKahootXD.Conexion;

namespace ProyectoKahootXD
{
    public class Preguntas
    {
        public int catPrin = 0;
        public int numPrin = 0;
        public string enunPrin = "";
        public string tipoPrin = "";
        public int idPrin = 0;

        // NUEVO: Lista estática para llevar el control de los IDs mostrados en la ronda
        public static List<int> preguntasRealizadas = new List<int>();

        Conexion conexion = new Conexion();

        public void getpregunta(int categoria)
        {
            MySqlConnection con = conexion.getConexion();

            // NUEVO: Construimos el query base
            string query = "SELECT categoria_id, numero_pregunta, id, enunciado, tipo_respuesta FROM preguntas WHERE categoria_id = " + categoria.ToString();

            // NUEVO: Si ya hay preguntas en la lista, las excluimos de la consulta
            if (preguntasRealizadas.Count > 0)
            {
                string excluidas = string.Join(",", preguntasRealizadas);
                query += " AND id NOT IN (" + excluidas + ")";
            }

            // Mantenemos el orden aleatorio y limit 1
            query += " ORDER BY rand() LIMIT 1;";

            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                catPrin = reader.GetInt32("categoria_id");
                numPrin = reader.GetInt32("numero_pregunta");
                idPrin = reader.GetInt32("id");
                enunPrin = reader.GetString("enunciado");
                tipoPrin = reader.GetString("tipo_respuesta");

                // NUEVO: Guardamos el ID de la pregunta que acaba de salir para no repetirla
                preguntasRealizadas.Add(idPrin);
            }

            reader.Close();
            con.Close();
        }
    }
}