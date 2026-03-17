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

namespace ProyectoKahootXD
{
    public partial class Form1 : Form
    {
        Preguntas pregunta = new Preguntas();
        Respuesta respuestas = new Respuesta();
        Asset asset = new Asset();
        public Form1(Preguntas preg, Respuesta resps)
        {
            InitializeComponent();
            pregunta = preg;
            respuestas = resps;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Debe seleccionar una respuesta");
            }
            /*else
            {
                if ()
                {

                    MessageBox.Show("Respuesta correcta");

                }
                else
                {
                    MessageBox.Show("Respuesta incorrecta");
                }*/
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
    }
}

