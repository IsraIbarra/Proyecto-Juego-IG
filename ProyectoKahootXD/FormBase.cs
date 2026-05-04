using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoKahootXD
{
    public class FormBase : Form
    {
        private Dictionary<Control, Rectangle> controlesOriginales = new Dictionary<Control, Rectangle>();
        private Size tamañoOriginalForm;


        public FormBase()
        {

            this.BackColor = Color.FromArgb(10, 10, 20);
            this.DoubleBuffered = true;
            this.Resize += FormBase_Resize;

            this.Load += (s, e) => {
                this.Size = new Size(1000, 700);
                this.CenterToScreen();
            };
        }

        public void InicializarEscalado()
        {
            if (this.Width > 0 && controlesOriginales.Count == 0)
            {
                tamañoOriginalForm = this.Size;
                foreach (Control c in this.Controls)
                {
                    controlesOriginales[c] = new Rectangle(c.Location, c.Size);
                }
            }
            AplicarEscalado();
        }

        private void FormBase_Resize(object sender, EventArgs e)
        {
            AplicarEscalado();
        }

        private void AplicarEscalado()
        {
            if (tamañoOriginalForm.Width == 0 || tamañoOriginalForm.Height == 0) return;

            float ratioAncho = (float)this.Width / (float)tamañoOriginalForm.Width;
            float ratioAlto = (float)this.Height / (float)tamañoOriginalForm.Height;

            foreach (var item in controlesOriginales)
            {
                Control c = item.Key;
                Rectangle rectOriginal = item.Value;

                c.Width = (int)(rectOriginal.Width * ratioAncho);
                c.Height = (int)(rectOriginal.Height * ratioAlto);
                c.Left = (int)(rectOriginal.Left * ratioAncho);
                c.Top = (int)(rectOriginal.Top * ratioAlto);
            }
        }

        public void NavegarA(FormBase siguiente)
        {
            siguiente.StartPosition = FormStartPosition.Manual;
            siguiente.Location = this.Location;
            siguiente.Size = this.Size;
            siguiente.WindowState = this.WindowState;
            siguiente.Show();
            this.Hide();
        }
    }
}