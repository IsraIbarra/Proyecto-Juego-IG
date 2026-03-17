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
    public partial class Texto : Form
    {
        Preguntas pregunta = new Preguntas();
        Respuesta respuestas = new Respuesta();
        public Texto(Preguntas preg, Respuesta resps)
        {
            InitializeComponent();
            pregunta = preg;
            respuestas = resps;

        }

        private void Texto_Load(object sender, EventArgs e)
        {

        }
    }
}
