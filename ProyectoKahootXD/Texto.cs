using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoKahootXD
{
    public partial class Texto : Form
    {
        Preguntas objetoPregunta;
        Respuesta objetoRespuesta;
        // Añadimos un contador para saber cuántas preguntas lleva el usuario
        int contadorPreguntas;
        int idResp = 0;
        int respsCorr;
        public Texto(Preguntas preg, Respuesta resps, int numeroActual,int respb)
        {
            InitializeComponent();
            this.objetoPregunta = preg;
            this.objetoRespuesta = resps;
            this.contadorPreguntas = numeroActual;
            this.respsCorr = respb;
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

            btnSiguiente.Hide();
        }

        // Este es el botón para avanzar
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.contadorPreguntas++;
            if (contadorPreguntas < 12)
            {
                // 1. Buscamos una nueva pregunta de la misma categoría
                Preguntas nuevaPreg = new Preguntas();
                Respuesta nuevasResp = new Respuesta();

                // Usamos el ID de categoría que ya traía la pregunta anterior
                // Necesitarás asegurar que la clase Preguntas guarde el ID de categoría
                // Para este ejemplo asumiremos que lo obtenemos de la base de datos de nuevo
                nuevaPreg.getpregunta(objetoPregunta.catPrin); // Aquí deberías pasar la categoría actual
                nuevasResp.getRespuestas(nuevaPreg.idPrin);

                // 2. Lógica para abrir el siguiente formulario según el tipo
                AbrirSiguienteForm(nuevaPreg, nuevasResp);

                this.Close(); // Cerramos el actual
            }
            else
            {
                MessageBox.Show("¡Has terminado las 12 preguntas!");
                Form4 principal = new Form4(respsCorr);
                principal.Show();
                this.Close();
            }
        }

        private void AbrirSiguienteForm(Preguntas p, Respuesta r)
        {
            int siguienteNumero = contadorPreguntas;

            switch (p.tipoPrin)
            {
                case "Texto":
                    Texto formTexto = new Texto(p, r, siguienteNumero,this.respsCorr);
                    formTexto.Show();
                    break;
                case "Imagen":
                    Form1 formImg = new Form1(p, r,this.contadorPreguntas,this.respsCorr); 
                    formImg.Show();
                    break;
                case "Audio":
                    Form3 formAud = new Form3(p, r,this.contadorPreguntas,this.respsCorr); 
                    formAud.Show();
                    break;
            }
        }

        private void resetBotones()
        {
            btnOpcionA.BackColor = Color.Gray;
            btnOpcionB.BackColor = Color.Gray;
            btnOpcionC.BackColor = Color.Gray;
            btnOpcionD.BackColor = Color.Gray;
        }

        private void seleccionarbtn(Button btn)
        {
            resetBotones();
            btn.BackColor = Color.Green;
            btn.FlatAppearance.BorderSize = 3;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void btnOpcionA_Click(object sender, EventArgs e)
        {
            seleccionarbtn(btnOpcionA);
            idResp = objetoRespuesta.respID_A;
        }

        private void btnOpcionB_Click(object sender, EventArgs e)
        {
            seleccionarbtn(btnOpcionB);
            idResp = objetoRespuesta.respID_B;
        }

        private void btnOpcionC_Click(object sender, EventArgs e)
        {
            seleccionarbtn(btnOpcionC);
            idResp = objetoRespuesta.respID_C;
        }

        private void btnOpcionD_Click(object sender, EventArgs e)
        {
            seleccionarbtn(btnOpcionD);
            idResp = objetoRespuesta.respID_D;
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (idResp == 0)
            {
                MessageBox.Show("Debe seleccionar una respuesta");
            }
            if (idResp == objetoRespuesta.respID_correcta)
            {
                MessageBox.Show("Respuesta Correcta", "Siguiente", MessageBoxButtons.OK);
                //agregar aqui la ID a un arreglo de visitados en la cs de preguntas 
                btnVerificar.Hide();
                btnSiguiente.Show();
                respsCorr++;

            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta", "Siguiente", MessageBoxButtons.OK);
                //agregar aqui la ID a un arreglo de visitados en la cs de preguntas 
                btnVerificar.Hide();
                btnSiguiente.Show();
            }
        }
    }
}
