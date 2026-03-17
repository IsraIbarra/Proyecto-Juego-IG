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

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer2_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer3_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer4_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label3.Text = pregunta.enunPrin;
            string a = asset.soundLoader(respuestas.resp_A);
            string b = asset.soundLoader(respuestas.resp_B);
            string c = asset.soundLoader(respuestas.resp_C);
            string d = asset.soundLoader(respuestas.resp_D);
            axWindowsMediaPlayer1.URL = a;
            axWindowsMediaPlayer2.URL = b;
            axWindowsMediaPlayer3.URL = c;
            axWindowsMediaPlayer4.URL = d;
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer2.settings.autoStart = false;
            axWindowsMediaPlayer3.settings.autoStart = false;
            axWindowsMediaPlayer4.settings.autoStart = false;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer2.uiMode = "none";
            axWindowsMediaPlayer3.uiMode = "none";
            axWindowsMediaPlayer4.uiMode = "none";

            if (pregunta.idPrin == 59)
            {
                string nombre = "cinAux1.jpeg";
                string rutaimg = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\..\Recursos\Imagenes\", nombre
            );
                pictureBoxpregunta.Visible = true;

                pictureBoxpregunta.Image = Image.FromFile(rutaimg);
                   
            }
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer2_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer3_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer3.Ctlcontrols.play();
        }

        private void axWindowsMediaPlayer4_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            axWindowsMediaPlayer4.Ctlcontrols.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer2.Ctlcontrols.stop();
            axWindowsMediaPlayer2.Ctlcontrols.play();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer3.Ctlcontrols.stop();
            axWindowsMediaPlayer3.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer4.Ctlcontrols.stop();
            axWindowsMediaPlayer4.Ctlcontrols.play();
        }
    }
}
