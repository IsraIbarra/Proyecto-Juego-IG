namespace ProyectoKahootXD
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTexto = new System.Windows.Forms.PictureBox();
            this.pbJugador = new System.Windows.Forms.PictureBox();
            this.pbMultijugador = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTexto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMultijugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTexto
            // 
            this.pbTexto.Location = new System.Drawing.Point(83, 31);
            this.pbTexto.Name = "pbTexto";
            this.pbTexto.Size = new System.Drawing.Size(606, 116);
            this.pbTexto.TabIndex = 0;
            this.pbTexto.TabStop = false;
            // 
            // pbJugador
            // 
            this.pbJugador.Location = new System.Drawing.Point(31, 199);
            this.pbJugador.Name = "pbJugador";
            this.pbJugador.Size = new System.Drawing.Size(184, 179);
            this.pbJugador.TabIndex = 1;
            this.pbJugador.TabStop = false;
            // 
            // pbMultijugador
            // 
            this.pbMultijugador.Location = new System.Drawing.Point(315, 199);
            this.pbMultijugador.Name = "pbMultijugador";
            this.pbMultijugador.Size = new System.Drawing.Size(184, 179);
            this.pbMultijugador.TabIndex = 2;
            this.pbMultijugador.TabStop = false;
            // 
            // pbSalir
            // 
            this.pbSalir.Location = new System.Drawing.Point(581, 199);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(184, 179);
            this.pbSalir.TabIndex = 3;
            this.pbSalir.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbSalir);
            this.Controls.Add(this.pbMultijugador);
            this.Controls.Add(this.pbJugador);
            this.Controls.Add(this.pbTexto);
            this.Name = "Menu";
            this.Text = "Kah00t";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTexto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMultijugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSalir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTexto;
        private System.Windows.Forms.PictureBox pbJugador;
        private System.Windows.Forms.PictureBox pbMultijugador;
        private System.Windows.Forms.PictureBox pbSalir;
    }
}