using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form3(Preguntas preg, Respuesta resps)
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


        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer3.settings.autoStart = false;
            axWindowsMediaPlayer4.settings.autoStart = false;

            //texto de la pregunta
            label3.Text = pregunta.enunPrin;
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
                pictureBoxpregunta.Left = label3.Right + 5;
                pictureBoxpregunta.Top = label3.Top;



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
    }
}
