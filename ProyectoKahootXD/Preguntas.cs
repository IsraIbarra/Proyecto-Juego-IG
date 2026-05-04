using System;
using System.Collections.Generic;

namespace ProyectoKahootXD
{
    public class Preguntas
    {
        public int catPrin = 0;
        public int numPrin = 0;
        public string enunPrin = "";
        public string tipoPrin = "";
        public int idPrin = 0;

        public static List<int> preguntasRealizadas = new List<int>();
        public static string categoriaJugada = "";
        public static string NombreUsuario = "Player1"; // Añadido para el multijugador

        public void getpregunta(int categoria)
        {
            // Leemos de la lista descargada en lugar de MySQL
            if (ServidorAPI.RondaActual != null && ServidorAPI.RondaActual.Count > 0)
            {
                // Buscamos la primera pregunta de la lista que no se haya jugado aún
                var datosPregunta = ServidorAPI.RondaActual.Find(p => !preguntasRealizadas.Contains(p.id));

                if (datosPregunta != null)
                {
                    this.idPrin = datosPregunta.id;
                    this.enunPrin = datosPregunta.enunciado;
                    this.tipoPrin = datosPregunta.tipo_respuesta;
                    this.catPrin = categoria;

                    // Registramos que ya salió para no repetirla en la siguiente ventana
                    preguntasRealizadas.Add(this.idPrin);
                }
            }
        }
    }
}