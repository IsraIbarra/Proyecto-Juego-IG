using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProyectoKahootXD
{
    public class ServidorAPI
    {
        private static readonly HttpClient client = new HttpClient();

        // Variable estática donde se guardan las 12 preguntas para todo el juego
        public static List<PreguntaDTO> RondaActual = new List<PreguntaDTO>();

        public async Task<List<PreguntaDTO>> DescargarRonda(int categoriaId)
        {
            // Recuerda cambiar 'localhost' por tu IP cuando juegues en red con otros
            string url = $"http://127.0.0.1:8000/trivia_v2/ronda/{categoriaId}";
            string response = await client.GetStringAsync(url);

            RondaActual = JsonConvert.DeserializeObject<List<PreguntaDTO>>(response);
            return RondaActual;
        }
    }

    // Clases DTO para mapear el JSON
    public class PreguntaDTO
    {
        public int id { get; set; }
        public string enunciado { get; set; }
        public string tipo_respuesta { get; set; }
        public List<OpcionDTO> opciones { get; set; }
    }

    public class OpcionDTO
    {
        public int id { get; set; }
        public string letra { get; set; }
        public string contenido { get; set; }
        public int correcta { get; set; }
    }
}