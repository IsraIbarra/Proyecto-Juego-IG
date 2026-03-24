using Org.BouncyCastle.Ocsp;
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
using static ProyectoKahootXD.Asset;
using static ProyectoKahootXD.Preguntas;
using static ProyectoKahootXD.Respuesta;

namespace ProyectoKahootXD
{
    public partial class Form1 : Form
    {
        Preguntas pregunta = new Preguntas();
        Respuesta respuestas = new Respuesta();
        Asset asset = new Asset();
        int contadorpreg;
        int respCorr ;


        Color colorTextoPrimario = Color.White;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);

        public Form1(Preguntas preg, Respuesta resps, int actual,int respb)
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

        private void Form1_Load(object sender, EventArgs e)
        {

            DibujarBotonControl(pbVerificar, "Verificar", Color.FromArgb(33, 150, 243));
            DibujarEncabezado(pbEncabezadoPregunta, contadorpreg, pregunta.enunPrin);
            pictureBox1.Image = asset.imagenLoader(respuestas.resp_A);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxB.Image = asset.imagenLoader(respuestas.resp_B);
            pictureBoxB.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxC.Image = asset.imagenLoader(respuestas.resp_C);
            pictureBoxC.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxD.Image = asset.imagenLoader(respuestas.resp_D);
            pictureBoxD.SizeMode = PictureBoxSizeMode.Zoom;
           
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox1.CheckedChanged += CheckBox2_CheckedChanged;
            
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox1_load(object sender, EventArgs e)
        {

        }
        private void pictureBoxB_load(object sender, EventArgs e)
        {


        }
        private void pictureBoxC_load(object sender, EventArgs e)
        {


        }
        private void pictureBoxD_load(object sender, EventArgs e)
        {
        }

        private void botonSig_Click(object sender, EventArgs e)
        {
            this.contadorpreg++;
            if (contadorpreg < 12)
            {
                Preguntas preguntaN = new Preguntas();
                Respuesta respuestasN = new Respuesta();

                preguntaN.getpregunta(pregunta.catPrin);
                respuestasN.getRespuestas(preguntaN.idPrin);
                switch (preguntaN.tipoPrin)
                {
                    case "Texto":
                        Texto texto = new Texto(preguntaN, respuestasN, this.contadorpreg, this.respCorr);
                        texto.Show();
                        this.Hide();
                        break;
                    case "Imagen":
                        Form1 imagen = new Form1(preguntaN, respuestasN, this.contadorpreg, this.respCorr);
                        imagen.Show();
                        this.Hide();
                        break;
                    case "Audio":
                        Form3 audio = new Form3(preguntaN, respuestasN, this.contadorpreg, this.respCorr);
                        audio.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                Form4 resultado = new Form4(respCorr);
                resultado.Show();
                this.Hide();
            }
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
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
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

