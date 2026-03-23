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
            Form2 formularioSecundario = new Form2();
            formularioSecundario.Show();
    }

        private void Form4_Load(object sender, EventArgs e)
        {
            labelRes.Text = respCorr.ToString();
        }
    }
}
