using System;

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

        public void getRespuestas(int idPregunta)
        {
            // Buscamos la pregunta en nuestra ronda actual en memoria
            var preguntaEnLista = ServidorAPI.RondaActual.Find(p => p.id == idPregunta);

            if (preguntaEnLista != null)
            {
                foreach (var opt in preguntaEnLista.opciones)
                {
                    if (opt.letra == "a") { resp_A = opt.contenido; respID_A = opt.id; }
                    else if (opt.letra == "b") { resp_B = opt.contenido; respID_B = opt.id; }
                    else if (opt.letra == "c") { resp_C = opt.contenido; respID_C = opt.id; }
                    else if (opt.letra == "d") { resp_D = opt.contenido; respID_D = opt.id; }

                    if (opt.correcta == 1)
                    {
                        respID_correcta = opt.id;
                    }
                }
            }
        }
    }
}