using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public static class SocketManager
    {
        // El cliente de WebSocket que se mantendrá vivo durante todo el juego
        public static ClientWebSocket WebSocketCliente = new ClientWebSocket();
        private static CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// Inicia la conexión con el servidor FastAPI
        /// </summary>
        /// <param name="username">Nombre del usuario para el registro en el lobby</param>
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
                // URL de tu servidor FastAPI (ajusta la IP si pruebas en red local)
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

                        // Aquí es donde puedes procesar los mensajes globales
                        // Ejemplo: "COUNT|5|2" o "START_ROULETTE|1"
                        ManejarMensajeServidor(mensaje);
                    }
                }
            }
            catch (Exception)
            {
                // Manejar desconexión inesperada aquí
            }
        }

        /// <summary>
        /// Envía un mensaje de texto al servidor 
        /// </summary>
        public static async Task EnviarMensaje(string mensaje)
        {
            if (WebSocketCliente.State == WebSocketState.Open)
            {
                //var bytes = Encoding.UTF8.GetBytes(mensaje);
                //await WebSocketCliente.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, cts.Token);
                byte[] buffer = Encoding.UTF8.GetBytes(mensaje);
                await WebSocketCliente.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None
                );
            }
        }

        private static void ManejarMensajeServidor(string mensaje)
        {
            // Este método puede ser usado para disparar eventos que tus Forms escuchen
            // Por ahora, solo sirve de puente para la lógica de tus compañeros
            Console.WriteLine("Mensaje recibido del servidor: " + mensaje);
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