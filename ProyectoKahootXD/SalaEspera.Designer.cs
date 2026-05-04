namespace ProyectoKahootXD
{
    partial class SalaEspera
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
            this.pbEncabezado = new System.Windows.Forms.PictureBox();
            this.pbContador = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEncabezado
            // 
            this.pbEncabezado.Location = new System.Drawing.Point(12, 12);
            this.pbEncabezado.Name = "pbEncabezado";
            this.pbEncabezado.Size = new System.Drawing.Size(776, 143);
            this.pbEncabezado.TabIndex = 0;
            this.pbEncabezado.TabStop = false;
            // 
            // pbContador
            // 
            this.pbContador.Location = new System.Drawing.Point(329, 176);
            this.pbContador.Name = "pbContador";
            this.pbContador.Size = new System.Drawing.Size(119, 74);
            this.pbContador.TabIndex = 1;
            this.pbContador.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(242, 300);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 138);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // SalaEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbContador);
            this.Controls.Add(this.pbEncabezado);
            this.Name = "SalaEspera";
            this.Text = "SalaEspera";
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbContador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEncabezado;
        private System.Windows.Forms.PictureBox pbContador;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}