using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class FormRuleta : FormBase
    {
        // --- Variables de la Ruleta ---
        private List<string> categorias = new List<string> { "Historia", "Música", "Deportes", "Ciencia", "Cine", "Geografía", "Computación" };

        // Variables para la animación controlada
        private float anguloActual = 0;
        private float anguloDestinoTotal = 0;
        private float progresoGiro = 0f;
        private Timer timerGiro;

        // Variables del juego
        private int idCategoriaGanadora;
        private Color colorTextoSecundario = Color.FromArgb(180, 180, 180);
        int contador = 1;
        int respCorr = 0;

        ServidorAPI api = new ServidorAPI();

        public FormRuleta(int idGanador)
        {
            InitializeComponent();
            this.Load += FormRuleta_Load;
            this.DoubleBuffered = true;
            this.Size = new Size(600, 750);

            this.idCategoriaGanadora = idGanador;

            // --- CÁLCULO TRAMPOSO PARA ATERRIZAR EN EL GANADOR ---
            // Los IDs empiezan en 1, pero nuestra lista en 0 (Historia = 0, Música = 1...)
            int indiceGanador = idCategoriaGanadora - 1;
            float sweepAngle = 360f / categorias.Count;

            // Calculamos en qué grado exacto debe detenerse para que la flecha apunte al centro de la categoría
            float anguloParaAterrizar = 360f - (indiceGanador * sweepAngle) - (sweepAngle / 2);

            // Le sumamos 5 vueltas completas (360 * 5) para que dé el efecto visual de girar rápido
            anguloDestinoTotal = (360f * 5) + anguloParaAterrizar;

            // Timer para animar el giro
            timerGiro = new Timer();
            timerGiro.Interval = 20; // 50 FPS aprox para que se vea muy fluido
            timerGiro.Tick += TimerGiro_Tick;
        }

        private async void FormRuleta_Load(object sender, EventArgs e)
        {
            this.InicializarEscalado();

            if (pbCargando != null)
            {
                DibujarEncabezado(pbCargando, "¡Todos listos!", "Girando la ruleta mágica...");
            }

            // Damos 1.5 segundos para que los jugadores lean el letrero antes de quitarlo
            await Task.Delay(1500);

            if (pbCargando != null) pbCargando.Visible = false;

            // Inicia la animación del giro
            timerGiro.Start();
        }

        private void TimerGiro_Tick(object sender, EventArgs e)
        {
            // Aumentamos el progreso de la animación (0f es el inicio, 1f es el final)
            // Cambiar el 0.012f hace que dure más o menos tiempo (actualmente dura unos 4 segundos)
            progresoGiro += 0.012f;

            if (progresoGiro >= 1f)
            {
                progresoGiro = 1f;
                timerGiro.Stop();
                TerminarGiro();
            }

            // Fórmula matemática "Ease-Out Cubic" para que frene suavemente al final
            float easeOut = 1f - (float)Math.Pow(1f - progresoGiro, 3);

            anguloActual = anguloDestinoTotal * easeOut;

            this.Invalidate(); // Redibujamos la ruleta con el nuevo ángulo
        }

        private async void TerminarGiro()
        {
            string nombreGanador = categorias[idCategoriaGanadora - 1];

            await Task.Delay(500);

            //MessageBox.Show($"¡La ruleta ha elegido: {nombreGanador}!", "Categoría Seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = nombreGanador;

            
            await LanzarJuego(idCategoriaGanadora);
        }

        // --- EL DIBUJO DE TU COMPAÑERO SE QUEDA CASI INTACTO ---
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Si el banner de cargando sigue visible, no dibujamos la ruleta aún
            //if (pbCargando != null && pbCargando.Visible) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

            int centroX = this.ClientSize.Width / 2;
            int centroY = (this.ClientSize.Height / 2) + 20;
            int radio = 200;
            float sweepAngle = 360f / categorias.Count;

            for (int i = 0; i < categorias.Count; i++)
            {
                float startAngle = anguloActual + (i * sweepAngle);

                using (Brush brush = new SolidBrush(GetColorForIndex(i)))
                {
                    g.FillPie(brush, centroX - radio, centroY - radio, radio * 2, radio * 2, startAngle, sweepAngle);
                }
                g.DrawPie(Pens.White, centroX - radio, centroY - radio, radio * 2, radio * 2, startAngle, sweepAngle);

                float anguloTexto = startAngle + (sweepAngle / 2);
                double rad = Math.PI * anguloTexto / 180.0;
                float tx = centroX + (float)(Math.Cos(rad) * (radio * 0.65));
                float ty = centroY + (float)(Math.Sin(rad) * (radio * 0.65));

                using (Font fontCat = new Font("Segoe UI", 10, FontStyle.Bold))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(categorias[i], fontCat, Brushes.White, tx, ty, sf);
                }
            }

            // Dibujar el indicador (flecha roja)
            Point[] flecha = {
                new Point(centroX + radio + 20, centroY - 15),
                new Point(centroX + radio + 20, centroY + 15),
                new Point(centroX + radio - 10, centroY)
            };
            g.FillPolygon(Brushes.Crimson, flecha);
            g.DrawPolygon(Pens.White, flecha);
        }

        private Color GetColorForIndex(int i)
        {
            Color[] palette = {
                Color.FromArgb(255, 87, 51),  // Naranja
                Color.FromArgb(51, 255, 87),  // Verde
                Color.FromArgb(51, 87, 255),  // Azul
                Color.FromArgb(255, 51, 161), // Rosa
                Color.FromArgb(255, 195, 0),  // Amarillo
                Color.FromArgb(144, 12, 63),  // Guinda
                Color.FromArgb(90, 34, 139)   // Morado
            };
            return palette[i % palette.Length];
        }

        private async Task LanzarJuego(int idCat)
        {
            try
            {
                // 1. Descargamos la ronda desde Python usando la categoría ganadora
                await api.DescargarRonda(idCat);

                // 2. Verificamos que sí hayan llegado datos
                if (ServidorAPI.RondaActual == null || ServidorAPI.RondaActual.Count == 0)
                {
                    MessageBox.Show("No se pudieron cargar las preguntas del servidor.");
                    return;
                }

                // 3. Preparamos las preguntas y respuestas
                Preguntas pregunta = new Preguntas();
                Respuesta respuestas = new Respuesta();
                pregunta.getpregunta(idCat);
                respuestas.getRespuestas(pregunta.idPrin);

                // 4. Navegamos al formulario correspondiente según el tipo de pregunta
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión al intentar cargar las preguntas: " + ex.Message);
            }
        }

        private void DibujarEncabezado(PictureBox pb, string titulo, string subtitulo)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (LinearGradientBrush brushFondo = new LinearGradientBrush(
                    new Point(0, 0), new Point(0, bmp.Height),
                    Color.FromArgb(10, 10, 20),
                    Color.FromArgb(26, 26, 46)))
                {
                    g.FillRectangle(brushFondo, 0, 0, bmp.Width, bmp.Height);
                }

                using (Font fuenteTitulo = new Font("Arial", 22, FontStyle.Bold))
                {
                    StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                    g.DrawString(titulo, fuenteTitulo, Brushes.White, new Rectangle(0, 20, bmp.Width, 50), formato);
                }

                using (Font fuenteSub = new Font("Segoe UI", 11, FontStyle.Bold))
                {
                    StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(subtitulo, fuenteSub, new SolidBrush(colorTextoSecundario), new Rectangle(10, 70, bmp.Width - 20, 50), formato);
                }
            }
            pb.Image = bmp;
        }
    }
}