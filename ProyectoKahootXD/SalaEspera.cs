using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class SalaEspera : FormBase
    {
        private PictureBox pbEstado;
        private PictureBox pbConteo;
        private PictureBox pbListo;
        private TableLayoutPanel layoutPrincipal;

        private int totalJugadores = 0;
        private int jugadoresListos = 0;
        private bool yaEstoyListo = false;

        // Colores de tu paleta
        Color colorFondo = Color.FromArgb(72, 61, 139);
        Color colorBotonNormal = Color.FromArgb(76, 175, 80); // Verde
        Color colorBotonPresionado = Color.FromArgb(100, 100, 100); // Gris

        public SalaEspera()
        {
            InicializarComponentes();
            this.InicializarEscalado();

            SocketManager.OnConteoActualizado += ActualizarConteo;
            SocketManager.OnRuletaIniciada += IrARuleta;
            this.totalJugadores = SocketManager.UltimosConectados;
            this.jugadoresListos = SocketManager.UltimosListos;
        }

        private void InicializarComponentes()
        {
            this.Text = "Sala de espera";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = colorFondo;

            // Usamos un Layout para que todo quede centrado y se escale bien
            layoutPrincipal = new TableLayoutPanel();
            layoutPrincipal.Dock = DockStyle.Fill;
            layoutPrincipal.RowCount = 4;
            layoutPrincipal.ColumnCount = 1;
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 30)); // Espacio arriba
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 20)); // Para pbEstado
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 20)); // Para pbConteo
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 30)); // Para pbListo

            // 1. PictureBox del Estado ("Esperando...")
            pbEstado = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            // 2. PictureBox del Conteo ("X listos; Z conectados")
            pbConteo = new PictureBox { Dock = DockStyle.Fill, BackColor = Color.Transparent };

            // 3. PictureBox del Botón Listo
            pbListo = new PictureBox();
            pbListo.Size = new Size(300, 80);
            pbListo.Anchor = AnchorStyles.None; // Para que se centre en su celda
            pbListo.Cursor = Cursors.Hand;
            pbListo.Click += PbListo_Click;

            // Agregamos al layout
            layoutPrincipal.Controls.Add(pbEstado, 0, 1);
            layoutPrincipal.Controls.Add(pbConteo, 0, 2);
            layoutPrincipal.Controls.Add(pbListo, 0, 3);

            this.Controls.Add(layoutPrincipal);

            // Dibujamos todo por primera vez cuando carga el form
            this.Load += (s, e) => RedibujarTodo();
        }

        // --- LÓGICA DE DIBUJO ---

        private void RedibujarTodo()
        {
            if (pbEstado.Width > 0 && pbEstado.Height > 0)
                DibujarTextoGrafico("Esperando...", pbEstado, 36, Color.White);

            if (pbConteo.Width > 0 && pbConteo.Height > 0)
            {
                string textoConteo = $"{jugadoresListos} jugadores Listos; {totalJugadores} jugadores conectados";
                DibujarTextoGrafico(textoConteo, pbConteo, 20, Color.LightGray);
            }

            if (pbListo.Width > 0 && pbListo.Height > 0)
            {
                string textoBoton = yaEstoyListo ? "ESPERANDO A LOS DEMÁS" : "¡ESTOY LISTO!";
                Color colorBoton = yaEstoyListo ? colorBotonPresionado : colorBotonNormal;
                DibujarBotonGrafico(textoBoton, pbListo, colorBoton);
            }
        }

        private void DibujarTextoGrafico(string texto, PictureBox pb, int tamanoFuente, Color colorTexto)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (Font fuente = new Font("Segoe UI", tamanoFuente, FontStyle.Bold))
                using (SolidBrush brocha = new SolidBrush(colorTexto))
                {
                    StringFormat formato = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    Rectangle area = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    g.DrawString(texto, fuente, brocha, area, formato);
                }
            }
            pb.Image = bmp;
        }

        private void DibujarBotonGrafico(string texto, PictureBox pb, Color colorFondoBoton)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Dibujamos el fondo del botón con bordes ligeramente redondeados (opcional, aquí es un rectángulo simple)
                using (SolidBrush brochaFondo = new SolidBrush(colorFondoBoton))
                {
                    g.FillRectangle(brochaFondo, 0, 0, bmp.Width, bmp.Height);
                }

                // Dibujamos el texto
                using (Font fuente = new Font("Segoe UI", 16, FontStyle.Bold))
                {
                    StringFormat formato = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };

                    Rectangle area = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    g.DrawString(texto, fuente, Brushes.White, area, formato);
                }
            }
            pb.Image = bmp;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RedibujarTodo(); // Redibujamos todo si el usuario cambia el tamaño de la ventana
        }

        // --- EVENTOS DEL JUEGO Y SOCKETS ---

        private async void PbListo_Click(object sender, EventArgs e)
        {
            if (yaEstoyListo) return; // Evita que mande "READY" varias veces

            yaEstoyListo = true;
            pbListo.Cursor = Cursors.Default; // Quitamos la manita del cursor

            // Le avisamos al servidor de Python
            await SocketManager.EnviarMensaje("READY");

            // Redibujamos el botón para que se vea gris
            RedibujarTodo();
        }

        public void ActualizarConteo(int total, int listos)
        {
            // Se invoca porque viene del hilo del Socket
            this.Invoke((MethodInvoker)delegate {
                this.totalJugadores = total;
                this.jugadoresListos = listos;

                // Redibujamos el texto del PictureBox con los nuevos datos
                RedibujarTodo();
            });
        }

        private void SalaEspera_Load(object sender, EventArgs e)
        {
            // Lo dejamos vacío para que el Designer sea feliz y no marque error
        }

        private void IrARuleta(int idCategoriaGanadora)
        {
            this.Invoke((MethodInvoker)delegate {
                SocketManager.OnConteoActualizado -= ActualizarConteo;
                SocketManager.OnRuletaIniciada -= IrARuleta;

                NavegarA(new FormRuleta(idCategoriaGanadora));
            });
        }
    }
}