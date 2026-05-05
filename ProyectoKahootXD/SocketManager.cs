using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProyectoKahootXD
{
    public static class SocketManager
    {
        // El cliente de WebSocket que se mantendrá vivo durante todo el juego
        public static ClientWebSocket WebSocketCliente = new ClientWebSocket();
        private static CancellationTokenSource cts = new CancellationTokenSource();

        public static event Action<int, int> OnConteoActualizado; // Manda (TotalJugadores, Listos)
        public static event Action<int> OnRuletaIniciada;         // Manda (IdCategoriaGanadora)
        public static event Action<string, int> OnGanadorAnunciado;
        public static string UsuarioLogueado { get; set; } = "JugadorDesconocido";

        /// <summary>
        /// Inicia la conexión con el servidor FastAPI
        /// </summary>
        public static async Task Conectar(string username)
        {
            // Si ya está conectado, no intentamos conectar de nuevo
            if (WebSocketCliente.State == WebSocketState.Open) return;

            // Si el socket estaba en un estado de error o cerrado, creamos una nueva instancia
            if (WebSocketCliente.State != WebSocketState.None && WebSocketCliente.State != WebSocketState.Connecting)
            {
                WebSocketCliente = new ClientWebSocket();
                cts = new CancellationTokenSource();
            }

            try
            {
                // URL de tu servidor FastAPI
                Uri serverUri = new Uri($"ws://127.0.0.1:8000/ws/{username}");

                // Establecer la conexión
                await WebSocketCliente.ConnectAsync(serverUri, cts.Token);

                // Iniciamos la escucha de mensajes en un hilo separado (segundo plano)
                _ = EscucharMensajes();
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo establecer conexión con el servidor de Sockets: " + ex.Message);
            }
        }

        /// <summary>
        /// Método que corre en segundo plano escuchando lo que manda Python
        /// </summary>
        private static async Task EscucharMensajes()
        {
            var buffer = new byte[1024 * 4];

            try
            {
                while (WebSocketCliente.State == WebSocketState.Open)
                {
                    var result = await WebSocketCliente.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await WebSocketCliente.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cts.Token);
                    }
                    else
                    {
                        // Convertir los bytes recibidos a texto
                        string mensaje = Encoding.UTF8.GetString(buffer, 0, result.Count);

                        // Mandamos el texto a procesar
                        ManejarMensajeServidor(mensaje);
                    }
                }
            }
            catch (Exception)
            {
                // Manejar desconexión inesperada aquí (ej. si el servidor se apaga de golpe)
            }
        }

        /// <summary>
        /// Envía un mensaje de texto al servidor 
        /// </summary>
        public static async Task EnviarMensaje(string mensaje)
        {
            if (WebSocketCliente.State == WebSocketState.Open)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(mensaje);
                await WebSocketCliente.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );
            }
        }

        /// <summary>
        /// Procesa los mensajes que llegan desde Python y dispara los eventos
        /// </summary>


        public static int UltimosConectados = 0;
        public static int UltimosListos = 0;
        private static void ManejarMensajeServidor(string mensaje)
        {
            Console.WriteLine("[SocketManager] Mensaje del servidor: " + mensaje);
            string[] partes = mensaje.Split('|');
            if (partes.Length == 0) return;

            // 1. Escuchar el conteo de jugadores
            if (partes[0] == "COUNT" && partes.Length >= 3)
            {
                if (int.TryParse(partes[1], out int total) && int.TryParse(partes[2], out int listos))
                {
                    UltimosConectados = total;
                    UltimosListos = listos;

                    OnConteoActualizado?.Invoke(total, listos);
                }
            }
            
            else if (partes[0] == "START_ROULETTE" && partes.Length >= 2)
            {
                // Le agregamos .Trim() por si viene con espacios invisibles
                if (int.TryParse(partes[1].Trim(), out int idCategoriaGanadora))
                {
                    // Disparamos el evento para que la Sala de Espera lo atrape
                    OnRuletaIniciada?.Invoke(idCategoriaGanadora);
                }
            }
            else if (partes[0] == "WINNER" && partes.Length >= 3)
            {
                string nombresGanadores = partes[1];
                if (int.TryParse(partes[2], out int puntajeGanador))
                {
                    OnGanadorAnunciado?.Invoke(nombresGanadores, puntajeGanador);
                }
            }
        }

        /// <summary>
        /// Cierra la conexión de forma segura al salir del juego
        /// </summary>
        public static async Task Desconectar()
        {
            if (WebSocketCliente.State == WebSocketState.Open)
            {
                await WebSocketCliente.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cierre voluntario", cts.Token);
            }
        }
    }
}