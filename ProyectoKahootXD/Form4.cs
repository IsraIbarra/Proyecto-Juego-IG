using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Form4 : Form
    {
        int respCorr = 0;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);

        public Form4(int respb)
        {
            InitializeComponent();
            this.respCorr = respb;

            this.pbRestart.Click += new System.EventHandler(this.pbRestart_Click);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DibujarEncabezado(pbEncabezado, "¡FELICIDADES!", "El juego ha concluido, esperamos que lo hayas disfrutado mucho");

            DibujarResultados(pbResultados);

            DibujarBotonControl(pbRestart, "RESTART", Color.FromArgb(255, 152, 0));
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

                using (Font fuenteTitulo = new Font("Arial", 24, FontStyle.Bold))
                {
                    StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                    g.DrawString(titulo, fuenteTitulo, Brushes.White, new Rectangle(0, 20, bmp.Width, 50), formato);
                }

                using (Font fuenteSub = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    StringFormat formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(subtitulo, fuenteSub, new SolidBrush(colorTextoSecundario), new Rectangle(10, 70, bmp.Width - 20, 50), formato);
                }
            }
            pb.Image = bmp;
        }

        private void DibujarResultados(PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(30, 30, 50));

                int incorrectas = 12 - respCorr;

                // --- PRUEBA AQUÍ ---
                string categoria = Preguntas.categoriaJugada;

                // Si la variable está vacía, le asignamos un texto de prueba para ver si se dibuja
                if (string.IsNullOrEmpty(categoria))
                {
                    categoria = "Sin Categoría (Error de asignación)";
                }

                using (Font fuenteCuerpo = new Font("Segoe UI", 16, FontStyle.Bold))
                {
                    g.DrawString($"PUNTUACIÓN FINAL: {respCorr} / 12", fuenteCuerpo, Brushes.White, 40, 50);
                    g.DrawString($"INCORRECTAS: {incorrectas}", fuenteCuerpo, new SolidBrush(Color.FromArgb(255, 100, 100)), 40, 110);

                    // Dibujamos la categoría
                    g.DrawString($"CATEGORÍA: {categoria.ToUpper()}", fuenteCuerpo, new SolidBrush(Color.Cyan), 40, 170);
                }
            }
            pb.Image = bmp;
        }

        private void DibujarBotonControl(PictureBox pb, string texto, Color colorFondo)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(colorFondo);

                using (Font fuente = new Font("Segoe UI", 12, FontStyle.Bold))
                {
                    StringFormat centro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(texto.ToUpper(), fuente, Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height), centro);
                }
            }
            pb.Image = bmp;
            pb.Cursor = Cursors.Hand;
        }

        private void pbRestart_Click(object sender, EventArgs e)
        {
            int incorrectas = 12 - respCorr;
            string detalle = $"Jugador: Player1 | Categoría: {Preguntas.categoriaJugada} | Correctas: {respCorr} | Incorrectas: {incorrectas}";

            try
            {
                Conexion conexion = new Conexion();
                MySqlConnection con = conexion.getConexion();
                string query = "INSERT INTO historial (detalle_partida) VALUES (@detalle)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@detalle", detalle);
                if (con.State != System.Data.ConnectionState.Open) con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }

            Form2 menu = new Form2();
            menu.Show();
            this.Close();
        }
    }
}