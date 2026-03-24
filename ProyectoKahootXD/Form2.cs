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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int contador = 1;
        int respCorr = 1;
        private void button_Historia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Historia";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(1);
            respuestas.getRespuestas(pregunta.idPrin);

            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta,respuestas, contador,respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta,respuestas,contador,respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta,respuestas,contador,respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }


        }

        private void button_Musica_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Música";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();
           
            pregunta.getpregunta(2);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas, contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }


        }

        private void button_Computacion_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Computación";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(7);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas, contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_Deportes_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Deportes";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(3);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas, contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }


        }

        private void button_Ciencia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Ciencia";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(4);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas,contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }


        }

        private void button_Cine_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Cine";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(5);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas, contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }

        }

        private void button_Geografia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Geografía";
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();

            pregunta.getpregunta(6);
            respuestas.getRespuestas(pregunta.idPrin);
            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    Texto texto = new Texto(pregunta, respuestas, contador, respCorr);
                    texto.Show();
                    this.Hide();
                    break;
                case "Imagen":
                    Form1 imagen = new Form1(pregunta, respuestas, contador, respCorr);
                    imagen.Show();
                    this.Hide();
                    break;
                case "Audio":
                    Form3 audio = new Form3(pregunta, respuestas, contador, respCorr);
                    audio.Show();
                    this.Hide();
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
