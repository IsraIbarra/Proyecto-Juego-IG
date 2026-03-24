using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public partial class Form4 : Form
    {
        int respCorr = 0;
        public Form4(int respb)
        {
            InitializeComponent();
            this.respCorr = respb;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            labelRes.Text = respCorr.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int incorrectas = 12 - respCorr;
            string detalle = $"Jugador: Player1 | Categoría: {Preguntas.categoriaJugada} | Correctas: {respCorr} | Incorrectas: {incorrectas}";

            Conexion conexion = new Conexion();
            MySqlConnection con = conexion.getConexion();
            string query = "INSERT INTO historial (detalle_partida) VALUES (@detalle)";

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@detalle", detalle);
            cmd.ExecuteNonQuery();

            con.Close();
            Form2 formularioSecundario = new Form2();
            formularioSecundario.Show();

            this.Close(); 
        }
    }
}