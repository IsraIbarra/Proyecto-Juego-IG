using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Menu : Form
    {
        Color colorFondoOpcion = Color.FromArgb(26, 26, 46);
        Color colorSeleccion = Color.FromArgb(76, 175, 80);
        Color colorTextoPrimario = Color.White;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);

        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DibujarEncabezado(pbTexto);
            DibujarBoton("Unjugador", pbJugador);
            DibujarBoton("multijugador", pbMultijugador);
            DibujarBoton("Salir", pbSalir);
        }

        private void DibujarEncabezado(PictureBox pb)
        {
            Bitmap bmp = new Bitmap(pb.Width, pb.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Calidad de renderizado
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;


                using (LinearGradientBrush brushFondo = new LinearGradientBrush(
                    new Point(0, 0), new Point(0, bmp.Height),
                    Color.FromArgb(10, 10, 20),
                    Color.FromArgb(26, 26, 46)))
                {
                    g.FillRectangle(brushFondo, 0, 0, bmp.Width, bmp.Height);
                }

                string titulo = "KAH00T";
                using (Font fuenteNumero = new Font("Arial", 20, FontStyle.Bold))
                {

                    StringFormat formatoNumero = new StringFormat();
                    formatoNumero.Alignment = StringAlignment.Far;
                    formatoNumero.LineAlignment = StringAlignment.Near;

                    Rectangle rectNumero = new Rectangle(10, 10, bmp.Width - 20, 25);
                    g.DrawString(titulo, fuenteNumero, new SolidBrush(colorTextoSecundario), rectNumero, formatoNumero);
                }


                /*using (Font fuenteEnunciado = new Font("Segoe UI", 16, FontStyle.Bold))
                {
                    // Lo centramos en el resto del PictureBox
                    StringFormat formatoEnunciado = new StringFormat();
                    formatoEnunciado.Alignment = StringAlignment.Center;
                    formatoEnunciado.LineAlignment = StringAlignment.Center;


                    Rectangle areaEnunciado = new Rectangle(15, 35, bmp.Width - 30, bmp.Height - 45);

                    g.DrawString(enunciado, fuenteEnunciado, Brushes.White, areaEnunciado, formatoEnunciado);
                }*/
            }

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





    }
}
