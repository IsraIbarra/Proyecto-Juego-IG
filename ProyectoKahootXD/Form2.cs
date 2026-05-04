using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ProyectoKahootXD
{
    public partial class Form2 : FormBase
    {
        int bandera;
        ServidorAPI api = new ServidorAPI();

        public Form2(int bandera_estilo)
        {
            this.bandera = bandera_estilo;
            InitializeComponent();
            this.InicializarEscalado();

            picBanner.Paint += PicBanner_Paint;
            picHistoria.Image = Properties.Resources.historia1;
            picMusica.Image = Properties.Resources.musica;
            picGeografia.Image = Properties.Resources.geografia;
        }

        int contador = 1;
        int respCorr = 0;

        private void button_Historia_Click(object sender, EventArgs e) { PrepararCategoria(1, "Historia"); }
        private void button_Musica_Click(object sender, EventArgs e) { PrepararCategoria(2, "Música"); }
        private void button_Deportes_Click(object sender, EventArgs e) { PrepararCategoria(3, "Deportes"); }
        private void button_Ciencia_Click(object sender, EventArgs e) { PrepararCategoria(4, "Ciencia"); }
        private void button_Cine_Click(object sender, EventArgs e) { PrepararCategoria(5, "Cine"); }
        private void button_Geografia_Click(object sender, EventArgs e) { PrepararCategoria(6, "Geografía"); }
        private void button_Computacion_Click(object sender, EventArgs e) { PrepararCategoria(7, "Computación"); }

        private void picHistoria_Click(object sender, EventArgs e) { PrepararCategoria(1, "Historia"); }
        private void picMusica_Click(object sender, EventArgs e) { PrepararCategoria(2, "Música"); }
        private void picGeografia_Click(object sender, EventArgs e) { PrepararCategoria(6, "Geografía"); }
        private void picCine_Click(object sender, EventArgs e) { PrepararCategoria(5, "Cine"); }
        private void picDeportes_Click(object sender, EventArgs e) { PrepararCategoria(3, "Deportes"); }
        private void picCiencia_Click(object sender, EventArgs e) { PrepararCategoria(4, "Ciencia"); }
        private void picComputacion_Click(object sender, EventArgs e) { PrepararCategoria(7, "Computación"); }

        private void PrepararCategoria(int idCat, string nombreCat)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = nombreCat;
            LanzarJuego(idCat);
        }

        // --- EL NUEVO LANZADOR ASÍNCRONO ---
        /* private async void LanzarJuego(int idCat)
         {
             try
             {
                 // Descargamos todas las preguntas desde la API de Python
                 await api.DescargarRonda(idCat);

                 if (ServidorAPI.RondaActual == null || ServidorAPI.RondaActual.Count == 0)
                 {
                     MessageBox.Show("No se pudieron cargar las preguntas del servidor.");
                     return;
                 }

                 // Generamos la primera pregunta
                 Preguntas pregunta = new Preguntas();
                 Respuesta respuestas = new Respuesta();
                 pregunta.getpregunta(idCat);
                 respuestas.getRespuestas(pregunta.idPrin);

                 // Lanzamos el formulario correspondiente a la primera pregunta
                 switch (pregunta.tipoPrin)
                 {
                     case "Texto":
                         NavegarA(new Texto(pregunta, respuestas, contador, respCorr));
                         break;
                     case "Imagen":
                         NavegarA(new Form1(pregunta, respuestas, contador, respCorr));
                         break;
                     case "Audio":
                         NavegarA(new Form3(pregunta, respuestas, contador, respCorr));
                         break;
                 }
                 this.Hide();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error de conexión: " + ex.Message);
             }
         }*/

        private async void LanzarJuego(int idCat)
        {
            try
            {
                // --- CASO MULTIJUGADOR (bandera == 2) ---
                if (this.bandera == 2)
                {
                    // 1. Avisamos al servidor qué categoría votamos/elegimos
                    // Podríamos enviar un mensaje por socket para que el servidor lo registre
                    await SocketManager.EnviarMensaje($"VOTE_CATEGORY|{idCat}");

                    // 2. Navegamos a la pantalla de espera (Lobby)
                    // Aquí tus compañeros deben crear el Form "EsperandoJugadores"
                    // NavegarA(new EsperandoJugadores(idCat)); 

                    // Por ahora, como ejemplo, podrías mandar un mensaje:
                    MessageBox.Show($"Categoría {Preguntas.categoriaJugada} seleccionada. Esperando a los demás...");
                    return; // Detenemos aquí, no descargamos preguntas todavía
                }

                // --- CASO UN JUGADOR (bandera == 1) ---
                // Tu lógica original se queda aquí:
                await api.DescargarRonda(idCat);

                if (ServidorAPI.RondaActual == null || ServidorAPI.RondaActual.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las preguntas del servidor.");
                    return;
                }

                Preguntas pregunta = new Preguntas();
                Respuesta respuestas = new Respuesta();
                pregunta.getpregunta(idCat);
                respuestas.getRespuestas(pregunta.idPrin);

                switch (pregunta.tipoPrin)
                {
                    case "Texto": NavegarA(new Texto(pregunta, respuestas, contador, respCorr)); break;
                    case "Imagen": NavegarA(new Form1(pregunta, respuestas, contador, respCorr)); break;
                    case "Audio": NavegarA(new Form3(pregunta, respuestas, contador, respCorr)); break;
                }
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }




        // --- EFECTOS VISUALES INTACTOS ---
        private void picHistoria_MouseEnter(object sender, EventArgs e) { picHistoria.Image = Properties.Resources.historia; }
        private void picHistoria_MouseLeave(object sender, EventArgs e) { picHistoria.Image = Properties.Resources.historia1; }
        private void picMusica_MouseEnter(object sender, EventArgs e) { picMusica.Image = Properties.Resources.musica1; }
        private void picMusica_MouseLeave(object sender, EventArgs e) { picMusica.Image = Properties.Resources.musica; }
        private void picGeografia_MouseEnter(object sender, EventArgs e) { picGeografia.Image = Properties.Resources.geografia1; }
        private void picGeografia_MouseLeave(object sender, EventArgs e) { picGeografia.Image = Properties.Resources.geografia; }
        private void picCine_MouseEnter(object sender, EventArgs e) { picCine.Image = Properties.Resources.cine1; }
        private void picCine_MouseLeave(object sender, EventArgs e) { picCine.Image = Properties.Resources.cine; }
        private void picDeportes_MouseEnter(object sender, EventArgs e) { picDeportes.Image = Properties.Resources.sports1; }
        private void picDeportes_MouseLeave(object sender, EventArgs e) { picDeportes.Image = Properties.Resources.sports; }
        private void picCiencia_MouseEnter(object sender, EventArgs e) { picCiencia.Image = Properties.Resources.ciencia1; }
        private void picCiencia_MouseLeave(object sender, EventArgs e) { picCiencia.Image = Properties.Resources.ciencia; }
        private void picComputacion_MouseEnter(object sender, EventArgs e) { picComputacion.Image = Properties.Resources.computacion1; }
        private void picComputacion_MouseLeave(object sender, EventArgs e) { picComputacion.Image = Properties.Resources.computacion; }

        private void PicBanner_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brushFondo = new LinearGradientBrush(
                new Point(0, 0), new Point(0, picBanner.Height),
                Color.FromArgb(15, 15, 30), Color.FromArgb(35, 35, 60)))
            {
                g.FillRectangle(brushFondo, 0, 0, picBanner.Width, picBanner.Height);
            }

            using (Pen borderPen = new Pen(Color.FromArgb(100, Color.White), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, picBanner.Width - 1, picBanner.Height - 1);
            }

            using (Font fontTitulo = new Font("Segoe UI", 20, FontStyle.Bold))
            {
                StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                Rectangle areaTop = new Rectangle(0, 0, picBanner.Width, picBanner.Height / 2);
                if (bandera == 1) g.DrawString("¡Bienvenido a nuestro juego!", fontTitulo, Brushes.White, areaTop, format);
                else if (bandera == 2) g.DrawString("Selecciona una Categoría!", fontTitulo, Brushes.White, areaTop, format);
            }

            using (Font fontSubtitulo = new Font("Segoe UI", 16, FontStyle.Regular))
            {
                StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                Rectangle areaBottom = new Rectangle(0, picBanner.Height / 2, picBanner.Width, picBanner.Height / 2);
                g.DrawString("Por favor, elige un tema de preguntas:", fontSubtitulo, Brushes.LightGray, areaBottom, format);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (picBanner != null) picBanner.Invalidate();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Lo dejamos vacío, solo sirve para que el Designer no se queje
        }
    }
}