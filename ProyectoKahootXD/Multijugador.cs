using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace ProyectoKahootXD
{

    public partial class Multijugador : FormBase

    {

        Color colorFondoOpcion = Color.FromArgb(26, 26, 46);

        Color colorSeleccion = Color.FromArgb(76, 175, 80);

        Color colorTextoPrimario = Color.White;

        Color colorTextoSecundario = Color.FromArgb(180, 180, 180);

        PrivateFontCollection misFuentes = new PrivateFontCollection();





        public Multijugador()

        {

            InitializeComponent();
            this.InicializarEscalado();

            string rutaFuente = Path.Combine(Application.StartupPath, "Resources", "PixelifySans-Regular.ttf");

            misFuentes.AddFontFile(rutaFuente);



        }





        private void Multijugador_Load(object sender, EventArgs e)

        {
            
            DibujarEncabezado(pbEncabezado);
            //DibujarBoton("Un jugador", pbHost);
            DibujarBoton("Entrar", pbJoin);

        }



        private void DibujarEncabezado(PictureBox pb)

        {

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);



            using (Graphics g = Graphics.FromImage(bmp))

            {

                g.Clear(Color.Transparent);

                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                g.SmoothingMode = SmoothingMode.AntiAlias;





                Font fuenteEnunciado;

                fuenteEnunciado = new Font("Segoe UI", 24, FontStyle.Bold);

                using (fuenteEnunciado)

                {

                    StringFormat formatoEnunciado = new StringFormat();

                    formatoEnunciado.Alignment = StringAlignment.Center;

                    formatoEnunciado.LineAlignment = StringAlignment.Center;



                    Rectangle areaEnunciado = new Rectangle(15, 35, bmp.Width - 30, bmp.Height - 45);



                    g.DrawString("Inserte Usuario: ", fuenteEnunciado, Brushes.White, areaEnunciado, formatoEnunciado);

                }

            }

            pb.BackColor = Color.Transparent;

            pb.Image = bmp;

        }



        private void DibujarBoton(string texto, PictureBox pb)

        {

            Bitmap bmp = new Bitmap(pb.Width, pb.Height);



            using (Graphics g = Graphics.FromImage(bmp))

            {

                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                g.SmoothingMode = SmoothingMode.AntiAlias;



                g.Clear(colorFondoOpcion);



                using (Font fuente = new Font("Segoe UI", 14, FontStyle.Bold))

                {

                    StringFormat centro = new StringFormat();

                    centro.Alignment = StringAlignment.Center;

                    centro.LineAlignment = StringAlignment.Center;



                    Rectangle area = new Rectangle(0, 0, bmp.Width, bmp.Height);

                    g.DrawString(texto, fuente, Brushes.White, area, centro);

                }

            }



            pb.Image = bmp;

            pb.Cursor = Cursors.Hand;

        }



        private void MarcarSeleccion(PictureBox pb)

        {

            //pbHost.BackColor = Color.Transparent; pbHost.Padding = new Padding(0);

            pbJoin.BackColor = Color.Transparent; pbJoin.Padding = new Padding(0);



            pb.BackColor = colorSeleccion;

            pb.Padding = new Padding(4);

        }



        protected override void OnResize(EventArgs e)

        {

            base.OnResize(e);





            if (pbEncabezado != null && pbEncabezado.Width > 0)

            {

                DibujarEncabezado(pbEncabezado);



                //DibujarBoton("Host", pbHost);

                DibujarBoton("Unirse", pbJoin);



            }

        }



        //private void pbHost_Click(object sender, EventArgs e) { MarcarSeleccion(pbHost); }



        private void pbJoin_Click(object sender, EventArgs e) { MarcarSeleccion(pbJoin); }



        private void pbHost_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        private void pbJoin_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                string query = "INSERT INTO historial (usuario) VALUES (@usuario)";
                Conexion conexion = new Conexion();
                MySqlConnection con = conexion.getConexion();
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@usuario", textBox1.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Usuario guardado con éxito");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                }

                NavegarA(new Form2(2));
            }else
            {
                MessageBox.Show("inserte un nombre porfavor!");
            }
        }


    }
}