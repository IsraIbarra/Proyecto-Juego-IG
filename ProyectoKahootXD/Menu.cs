using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Menu : FormBase
    {
        Color colorFondoOpcion = Color.FromArgb(26, 26, 46);
        Color colorSeleccion = Color.FromArgb(76, 175, 80);
        Color colorTextoPrimario = Color.White;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);
        PrivateFontCollection misFuentes = new PrivateFontCollection();

        public Menu()
        {
            InitializeComponent();
            this.InicializarEscalado();

            string rutaFuente = Path.Combine(Application.StartupPath, "Resources", "PixelifySans-Regular.ttf");
            misFuentes.AddFontFile(rutaFuente);
    
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DibujarEncabezado(pbTexto);
            DibujarBoton("Un jugador", pbJugador);
            DibujarBoton("Multijugador", pbMultijugador);
            DibujarBoton("Salir", pbSalir);
        }

        private void DibujarEncabezado(PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Calidad de renderizado
                g.Clear(Color.Transparent);
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;

               
                Font fuenteEnunciado;
                if (misFuentes.Families.Length > 0)
                {
                    fuenteEnunciado = new Font(misFuentes.Families[0], 48, FontStyle.Regular);
                }
                else
                {
                    fuenteEnunciado = new Font("Segoe UI", 24, FontStyle.Bold);
                }

                using (fuenteEnunciado)
                {
                    StringFormat formatoEnunciado = new StringFormat();
                    formatoEnunciado.Alignment = StringAlignment.Center;
                    formatoEnunciado.LineAlignment = StringAlignment.Center;

                    Rectangle areaEnunciado = new Rectangle(15, 35, bmp.Width - 30, bmp.Height - 45);

                    g.DrawString("KAH00T", fuenteEnunciado, Brushes.White, areaEnunciado, formatoEnunciado);
                }
            }
            pb.BackColor = Color.Transparent;
            pb.Image = bmp;
        }

        private void DibujarBoton(string texto, PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.Clear(colorFondoOpcion);

                using (Font fuente = new Font("Segoe UI", 14, FontStyle.Bold))
                {
                    StringFormat centro = new StringFormat();
                    centro.Alignment = StringAlignment.Center;
                    centro.LineAlignment = StringAlignment.Center;

                    Rectangle area = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    g.DrawString(texto, fuente, Brushes.White, area, centro);
                }
            }

            pb.Image = bmp;
            pb.Cursor = Cursors.Hand;
        }

        private void MarcarSeleccion(PictureBox pb)
        {
            pbJugador.BackColor = Color.Transparent; pbJugador.Padding = new Padding(0);
            pbMultijugador.BackColor = Color.Transparent; pbMultijugador.Padding = new Padding(0);
            pbSalir.BackColor = Color.Transparent; pbSalir.Padding = new Padding(0);

            pb.BackColor = colorSeleccion;
            pb.Padding = new Padding(4);
        }

        private void pbJugador_Click(object sender, EventArgs e) { MarcarSeleccion(pbJugador); }
        private void pbMultijugador_Click(object sender, EventArgs e) { MarcarSeleccion(pbMultijugador); }
        private void pbSalir_Click(object sender, EventArgs e) { MarcarSeleccion(pbSalir); }

        private void pbJugador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NavegarA(new Form2(1));
        }

        private void pbSalir_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pbMultijugador_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NavegarA(new Multijugador());
        }




        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e); 


            if (pbTexto != null && pbTexto.Width > 0)
            {
                DibujarEncabezado(pbTexto);

                DibujarBoton("Un Jugador", pbJugador);
                DibujarBoton("Multijugador", pbMultijugador);
                DibujarBoton("Salir", pbSalir);
            }
        }




    }

}