using Org.BouncyCastle.Ocsp;
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
using static ProyectoKahootXD.Asset;
using static ProyectoKahootXD.Preguntas;
using static ProyectoKahootXD.Respuesta;

namespace ProyectoKahootXD
{
    public partial class Form3 : Form
    {
        Preguntas pregunta = new Preguntas();
        Respuesta respuestas = new Respuesta();
        Asset asset = new Asset();
        int contadorpreg ;
        int respCorr ;



        Color colorTextoPrimario = Color.White;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);
        public Form3(Preguntas preg, Respuesta resps, int actual,int respb)
        {
            InitializeComponent();
            this.pregunta = preg;
            this.respuestas = resps;
            this.contadorpreg = actual;
            this.respCorr = respb;
            

        }
        int checkbox_id = 0;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkbox_id = respuestas.respID_A;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkbox_id = respuestas.respID_B;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkbox_id = respuestas.respID_C;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkbox_id = respuestas.respID_D;

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer3.settings.autoStart = false;
            axWindowsMediaPlayer4.settings.autoStart = false;

            DibujarBotonControl(pbVerificar, "Verificar", Color.FromArgb(33, 150, 243));
            DibujarEncabezado(pbEncabezado, contadorpreg, pregunta.enunPrin);
            //las respuestas
            string a = asset.soundLoader(respuestas.resp_A);
            string b = asset.soundLoader(respuestas.resp_B);
            string c = asset.soundLoader(respuestas.resp_C);
            string d = asset.soundLoader(respuestas.resp_D);
            axWindowsMediaPlayer1.URL = a;
            axWindowsMediaPlayer2.URL = b;
            axWindowsMediaPlayer3.URL = c;
            axWindowsMediaPlayer4.URL = d;

            //pregunta de cine especial
            if (pregunta.idPrin == 59)
            {
                
                string nombre = "cinAux1.jpeg"; string rutaimg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"..\..\..\Recursos\Imagenes\", nombre);
                pictureBoxpregunta.Visible = true;

                pictureBoxpregunta.Image = Image.FromFile(rutaimg);

            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
           
        }

        private void axWindowsMediaPlayer2_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {

        }

        private void axWindowsMediaPlayer3_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {

        }

        private void axWindowsMediaPlayer4_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            
        }

        private void DibujarEncabezado(PictureBox pb, int numeroPregunta, string enunciado)
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

                string textoNumero = $"PREGUNTA {numeroPregunta} DE 12";
                using (Font fuenteNumero = new Font("Arial", 11, FontStyle.Bold))
                {

                    StringFormat formatoNumero = new StringFormat();
                    formatoNumero.Alignment = StringAlignment.Far;
                    formatoNumero.LineAlignment = StringAlignment.Near;

                    Rectangle rectNumero = new Rectangle(10, 10, bmp.Width - 20, 25);
                    g.DrawString(textoNumero, fuenteNumero, new SolidBrush(colorTextoSecundario), rectNumero, formatoNumero);
                }


                using (Font fuenteEnunciado = new Font("Segoe UI", 16, FontStyle.Bold))
                {

                    StringFormat formatoEnunciado = new StringFormat();
                    formatoEnunciado.Alignment = StringAlignment.Center;
                    formatoEnunciado.LineAlignment = StringAlignment.Center;


                    Rectangle areaEnunciado = new Rectangle(15, 35, bmp.Width - 30, bmp.Height - 45);

                    g.DrawString(enunciado, fuenteEnunciado, Brushes.White, areaEnunciado, formatoEnunciado);
                }
            }

            pb.Image = bmp;
        }

        private void pictureBoxB_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
        }

        private void pictureBoxC_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
        }

        private void pictureBoxD_Click(object sender, EventArgs e)
        {
            checkBox4.Checked = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
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
                    StringFormat centro = new StringFormat();
                    centro.Alignment = StringAlignment.Center;
                    centro.LineAlignment = StringAlignment.Center;

                    Rectangle area = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    g.DrawString(texto.ToUpper(), fuente, Brushes.White, area, centro);
                }
            }

            pb.Image = bmp;
            pb.Cursor = Cursors.Hand;
        }

        private void pbVerificar_Click(object sender, EventArgs e)
        {
            if (checkbox_id == 0)
            {
                MessageBox.Show("¡Selecciona una respuesta primero!");
                return;
            }

            if (checkbox_id == respuestas.respID_correcta)
            {
                MessageBox.Show("¡Correcto!");
                respCorr++;
            }
            else
            {
                MessageBox.Show("Incorrecto...");
            }


            pbVerificar.Visible = false;
            pbSiguiente.Visible = true;


            DibujarBotonControl(pbSiguiente, "Siguiente Pregunta", Color.FromArgb(255, 152, 0)); // Naranja
        }

        private void pbSiguiente_Click(object sender, EventArgs e)
        {
            this.contadorpreg++;
            if (contadorpreg <= 12)
            {
                Preguntas nuevaPreg = new Preguntas();
                Respuesta nuevasResp = new Respuesta();

                nuevaPreg.getpregunta(pregunta.catPrin);
                nuevasResp.getRespuestas(nuevaPreg.idPrin);

                AbrirSiguienteForm(nuevaPreg, nuevasResp);
                this.Close();
            }
            else
            {
                MessageBox.Show("Felicidades! Completaste el Quiz.");
                Form4 final = new Form4(respCorr);
                final.Show();
                this.Close();
            }
        }

        private void AbrirSiguienteForm(Preguntas p, Respuesta r)
        {
            switch (p.tipoPrin)
            {
                case "Texto":
                    new Texto(p, r, contadorpreg, respCorr).Show();
                    break;
                case "Imagen":
                    new Form1(p, r, contadorpreg, respCorr).Show();
                    break;
                case "Audio":
                    new Form3(p, r, contadorpreg, respCorr).Show();
                    break;
            }
        }

    }
}
