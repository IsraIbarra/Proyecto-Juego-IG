using System;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Drawing.Text;     
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Texto : Form
    {

        Preguntas objetoPregunta;
        Respuesta objetoRespuesta;
        int contadorPreguntas;
        int idResp = 0;
        int respsCorr;

        Color colorFondoOpcion = Color.FromArgb(26, 26, 46);
        Color colorSeleccion = Color.FromArgb(76, 175, 80);
        Color colorTextoPrimario = Color.White;
        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);

        public Texto(Preguntas preg, Respuesta resps, int numeroActual, int respb)
        {
            InitializeComponent();
            this.objetoPregunta = preg;
            this.objetoRespuesta = resps;
            this.contadorPreguntas = numeroActual;
            this.respsCorr = respb;
        }

        private void Texto_Load(object sender, EventArgs e)
        {

            lblEnunciado.Text = objetoPregunta.enunPrin;
            lblNumero.Text = $"Pregunta: {contadorPreguntas} / 12";


            DibujarEncabezado(pbEncabezadoPregunta, contadorPreguntas, objetoPregunta.enunPrin);

            pbSiguiente.Visible = false;
            pbVerificar.Visible = true;


            btnOpcionA.Hide();
            btnOpcionB.Hide();
            btnOpcionC.Hide();
            btnOpcionD.Hide();
            btnSiguiente.Hide();
            btnVerificar.Hide();

            DibujarBotonControl(pbVerificar, "Verificar", Color.FromArgb(33, 150, 243));

            DibujarBotonRespuesta(objetoRespuesta.resp_A, pbA);
            DibujarBotonRespuesta(objetoRespuesta.resp_B, pbB);
            DibujarBotonRespuesta(objetoRespuesta.resp_C, pbC);
            DibujarBotonRespuesta(objetoRespuesta.resp_D, pbD);
        }

        private void DibujarBotonRespuesta(string texto, PictureBox pb)
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

        private void pbA_Click(object sender, EventArgs e) { MarcarSeleccion(objetoRespuesta.respID_A, pbA); }
        private void pbB_Click(object sender, EventArgs e) { MarcarSeleccion(objetoRespuesta.respID_B, pbB); }
        private void pbC_Click(object sender, EventArgs e) { MarcarSeleccion(objetoRespuesta.respID_C, pbC); }
        private void pbD_Click(object sender, EventArgs e) { MarcarSeleccion(objetoRespuesta.respID_D, pbD); }

        private void MarcarSeleccion(int id, PictureBox pb)
        {
            idResp = id;

            pbA.BackColor = Color.Transparent; pbA.Padding = new Padding(0);
            pbB.BackColor = Color.Transparent; pbB.Padding = new Padding(0);
            pbC.BackColor = Color.Transparent; pbC.Padding = new Padding(0);
            pbD.BackColor = Color.Transparent; pbD.Padding = new Padding(0);

            pb.BackColor = colorSeleccion;
            pb.Padding = new Padding(4);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (idResp == 0)
            {
                MessageBox.Show("Por favor, selecciona una respuesta.");
                return;
            }

            if (idResp == objetoRespuesta.respID_correcta)
            {
                MessageBox.Show("Respuesta Correcta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                respsCorr++;
            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnVerificar.Hide();
            btnSiguiente.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.contadorPreguntas++;
            if (contadorPreguntas <= 12)
            {
                Preguntas nuevaPreg = new Preguntas();
                Respuesta nuevasResp = new Respuesta();

                nuevaPreg.getpregunta(objetoPregunta.catPrin);
                nuevasResp.getRespuestas(nuevaPreg.idPrin);

                AbrirSiguienteForm(nuevaPreg, nuevasResp);
                this.Close();
            }
            else
            {
                MessageBox.Show("Felicidades! Completaste el Quiz.");
                Form4 final = new Form4(respsCorr);
                final.Show();
                this.Close();
            }
        }

        private void AbrirSiguienteForm(Preguntas p, Respuesta r)
        {
            switch (p.tipoPrin)
            {
                case "Texto":
                    new Texto(p, r, contadorPreguntas, respsCorr).Show();
                    break;
                case "Imagen":
                    new Form1(p, r, contadorPreguntas, respsCorr).Show();
                    break;
                case "Audio":
                    new Form3(p, r, contadorPreguntas, respsCorr).Show();
                    break;
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
                    // Lo centramos en el resto del PictureBox
                    StringFormat formatoEnunciado = new StringFormat();
                    formatoEnunciado.Alignment = StringAlignment.Center;
                    formatoEnunciado.LineAlignment = StringAlignment.Center;


                    Rectangle areaEnunciado = new Rectangle(15, 35, bmp.Width - 30, bmp.Height - 45);

                    g.DrawString(enunciado, fuenteEnunciado, Brushes.White, areaEnunciado, formatoEnunciado);
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

                // Dibujamos el fondo con el color elegido
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
            if (idResp == 0)
            {
                MessageBox.Show("¡Selecciona una respuesta primero!");
                return;
            }

            if (idResp == objetoRespuesta.respID_correcta)
            {
                MessageBox.Show("¡Correcto!");
                respsCorr++;
            }
            else
            {
                MessageBox.Show("Incorrecto...");
            }

            // Cambiamos visibilidad de los PictureBox
            pbVerificar.Visible = false;
            pbSiguiente.Visible = true;

            // Dibujamos el botón siguiente al momento de mostrarlo
            DibujarBotonControl(pbSiguiente, "Siguiente Pregunta", Color.FromArgb(255, 152, 0)); // Naranja
        }

        private void pbSiguiente_Click(object sender, EventArgs e)
        {
            this.contadorPreguntas++;
            if (contadorPreguntas <= 12)
            {
                Preguntas nuevaPreg = new Preguntas();
                Respuesta nuevasResp = new Respuesta();

                nuevaPreg.getpregunta(objetoPregunta.catPrin);
                nuevasResp.getRespuestas(nuevaPreg.idPrin);

                AbrirSiguienteForm(nuevaPreg, nuevasResp);
                this.Close();
            }
            else
            {
                MessageBox.Show("Felicidades! Completaste el Quiz.");
                Form4 final = new Form4(respsCorr);
                final.Show();
                this.Close();
            }   
        }

    }
}