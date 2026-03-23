using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoKahootXD.Preguntas;
using static ProyectoKahootXD.Asset;
using static ProyectoKahootXD.Respuesta;
using Org.BouncyCastle.Ocsp;

namespace ProyectoKahootXD
{
    public partial class Form1 : Form
    {
        Preguntas pregunta = new Preguntas();
        Respuesta respuestas = new Respuesta();
        Asset asset = new Asset();
        int contadorpreg;
        int respCorr ;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Debe seleccionar una respuesta");
            }
            if (checkbox_id == respuestas.respID_correcta)
            {
                MessageBox.Show("Respuesta Correcta", "Siguiente", MessageBoxButtons.OK);
                //agregar aqui la ID a un arreglo de visitados en la cs de preguntas 
                button1.Hide();
                botonSig.Show();
                respCorr = respCorr + 1;
            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta", "Siguiente", MessageBoxButtons.OK);
                //agregar aqui la ID a un arreglo de visitados en la cs de preguntas 
                button1.Hide();
                botonSig.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = pregunta.enunPrin;
            pictureBox1.Image = asset.imagenLoader(respuestas.resp_A);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxB.Image = asset.imagenLoader(respuestas.resp_B);
            pictureBoxB.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxC.Image = asset.imagenLoader(respuestas.resp_C);
            pictureBoxC.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxD.Image = asset.imagenLoader(respuestas.resp_D);
            pictureBoxD.SizeMode = PictureBoxSizeMode.Zoom;
            botonSig.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label4_load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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


    }
}

