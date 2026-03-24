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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            picBanner.Paint += PicBanner_Paint;
            picHistoria.Image = Properties.Resources.historia1;
            picMusica.Image = Properties.Resources.musica;
            picGeografia.Image = Properties.Resources.geografia;

        }
        int contador = 1;
        int respCorr = 0; // Lo bajé a 0 para que el conteo sea real desde el inicio
        //private string textoParaDibujar = "prueba";
        private string textoParaDibujar = "";

        private void button_Historia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Historia";
            LanzarJuego(1);
        }

        private void button_Musica_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Música";
            LanzarJuego(2);
        }

        private void button_Deportes_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Deportes";
            LanzarJuego(3);
        }

        private void button_Ciencia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Ciencia";
            LanzarJuego(4);
        }

        private void button_Cine_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Cine";
            LanzarJuego(5);
        }

        private void button_Geografia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Geografía";
            LanzarJuego(6);
        }

        private void button_Computacion_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Computación";
            LanzarJuego(7);
        }

        // Métodos de las imágenes
        private void picHistoria_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Historia";
            LanzarJuego(1);
        }

        private void picMusica_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Música";
            LanzarJuego(2);
        }

        private void picGeografia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Geografía";
            LanzarJuego(6);
        }

        private void picCine_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Cine";
            LanzarJuego(5);
        }

        private void picDeportes_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Deportes";
            LanzarJuego(3);
        }

        private void picCiencia_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Ciencia";
            LanzarJuego(4);
        }

        private void picComputacion_Click(object sender, EventArgs e)
        {
            Preguntas.preguntasRealizadas.Clear();
            Preguntas.categoriaJugada = "Computación";
            LanzarJuego(7);
        }

        // Método auxiliar para no repetir el switch en todos lados
        private void LanzarJuego(int idCat)
        {
            Preguntas pregunta = new Preguntas();
            Respuesta respuestas = new Respuesta();
            pregunta.getpregunta(idCat);
            respuestas.getRespuestas(pregunta.idPrin);

            switch (pregunta.tipoPrin)
            {
                case "Texto":
                    new Texto(pregunta, respuestas, contador, respCorr).Show();
                    break;
                case "Imagen":
                    new Form1(pregunta, respuestas, contador, respCorr).Show();
                    break;
                case "Audio":
                    new Form3(pregunta, respuestas, contador, respCorr).Show();
                    break;
            }
            this.Hide();
        }

        // --- EFECTOS VISUALES ---
        private void picHistoria_MouseEnter(object sender, EventArgs e) { picHistoria.Image = Properties.Resources.historia; }
        private void picHistoria_MouseLeave(object sender, EventArgs e) { picHistoria.Image = Properties.Resources.historia1; }
        private void picMusica_MouseEnter(object sender, EventArgs e) { picMusica.Image = Properties.Resources.musica1; }
        private void picMusica_MouseLeave(object sender, EventArgs e) { picMusica.Image = Properties.Resources.musica; }
        private void picGeografia_MouseEnter(object sender, EventArgs e) { picGeografia.Image = Properties.Resources.geografia1; }
        private void picGeografia_MouseLeave(object sender, EventArgs e) { picGeografia.Image = Properties.Resources.geografia; }
        private void picCine_MouseEnter(object sender, EventArgs e) { picCine.Image = Properties.Resources.cine1; }
        private void picCine_MouseLeave(object sender, EventArgs e) { picCine.Image = Properties.Resources.cine; }
        private void picDeportes_MouseEnter(object sender, EventArgs e) { picDeportes.Image = Properties.Resources.sports1; }
        private void picDeportes_MouseLeave(object sender, EventArgs e) { picDeportes.Image = Properties.Resources.sports; }
        private void picCiencia_MouseEnter(object sender, EventArgs e) { picCiencia.Image = Properties.Resources.ciencia1; }
        private void picCiencia_MouseLeave(object sender, EventArgs e) { picCiencia.Image = Properties.Resources.ciencia; }
        private void picComputacion_MouseEnter(object sender, EventArgs e) { picComputacion.Image = Properties.Resources.computacion1; }
        private void picComputacion_MouseLeave(object sender, EventArgs e) { picComputacion.Image = Properties.Resources.computacion; }

        private void PicBanner_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brushFondo = new LinearGradientBrush(
                new Point(0, 0), new Point(0, picBanner.Height),
                Color.FromArgb(15, 15, 30),
                Color.FromArgb(35, 35, 60)))
            {
                g.FillRectangle(brushFondo, 0, 0, picBanner.Width, picBanner.Height);
            }

            using (Pen borderPen = new Pen(Color.FromArgb(100, Color.White), 1))
            {
                g.DrawRectangle(borderPen, 0, 0, picBanner.Width - 1, picBanner.Height - 1);
            }

            using (Font fontTitulo = new Font("Segoe UI", 20, FontStyle.Bold))
            {
                StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                Rectangle areaTop = new Rectangle(0, 0, picBanner.Width, picBanner.Height / 2);
                g.DrawString("¡Bienvenido a nuestro juego!", fontTitulo, Brushes.White, areaTop, format);
            }

            using (Font fontSubtitulo = new Font("Segoe UI", 16, FontStyle.Regular))
            {
                StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
                Rectangle areaBottom = new Rectangle(0, picBanner.Height / 2, picBanner.Width, picBanner.Height / 2);
                g.DrawString("Por favor, elige un tema de preguntas:", fontSubtitulo, Brushes.LightGray, areaBottom, format);
            }
        }

        // Otros eventos vacíos
        private void Form2_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void picBanner_Click(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
    }
}