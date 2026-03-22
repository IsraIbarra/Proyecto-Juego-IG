using System;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Texto : Form
    {
        Preguntas objetoPregunta;
        Respuesta objetoRespuesta;
        // Añadimos un contador para saber cuántas preguntas lleva el usuario
        int contadorPreguntas;

        public Texto(Preguntas preg, Respuesta resps, int numeroActual = 1)
        {
            InitializeComponent();
            this.objetoPregunta = preg;
            this.objetoRespuesta = resps;
            this.contadorPreguntas = numeroActual;
        }

        private void Texto_Load(object sender, EventArgs e)
        {
            // Al cargar el form, asignamos los textos a los controles
            // Asume que tienes estos nombres de controles en tu diseño:
            lblEnunciado.Text = objetoPregunta.enunPrin;
            lblNumero.Text = "Pregunta: " + contadorPreguntas + " / 12";

            btnOpcionA.Text = objetoRespuesta.resp_A;
            btnOpcionB.Text = objetoRespuesta.resp_B;
            btnOpcionC.Text = objetoRespuesta.resp_C;
            btnOpcionD.Text = objetoRespuesta.resp_D;
        }

        // Este es el botón para avanzar
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (contadorPreguntas < 12)
            {
                // 1. Buscamos una nueva pregunta de la misma categoría
                Preguntas nuevaPreg = new Preguntas();
                Respuesta nuevasResp = new Respuesta();

                // Usamos el ID de categoría que ya traía la pregunta anterior
                // Necesitarás asegurar que la clase Preguntas guarde el ID de categoría
                // Para este ejemplo asumiremos que lo obtenemos de la base de datos de nuevo
                nuevaPreg.getpregunta(1); // Aquí deberías pasar la categoría actual
                nuevasResp.getRespuestas(nuevaPreg.idPrin);

                // 2. Lógica para abrir el siguiente formulario según el tipo
                AbrirSiguienteForm(nuevaPreg, nuevasResp);

                this.Close(); // Cerramos el actual
            }
            else
            {
                MessageBox.Show("¡Has terminado las 12 preguntas!");
                Form2 principal = new Form2();
                principal.Show();
                this.Close();
            }
        }

        private void AbrirSiguienteForm(Preguntas p, Respuesta r)
        {
            int siguienteNumero = contadorPreguntas + 1;

            switch (p.tipoPrin)
            {
                case "Texto":
                    Texto formTexto = new Texto(p, r, siguienteNumero);
                    formTexto.Show();
                    break;
                case "Imagen":
                    Form1 formImg = new Form1(p, r); // Aquí deberías adaptar Form1 para recibir el contador
                    formImg.Show();
                    break;
                case "Audio":
                    Form3 formAud = new Form3(p, r); // Aquí deberías adaptar Form3 para recibir el contador
                    formAud.Show();
                    break;
            }
        }

        
    }
}
